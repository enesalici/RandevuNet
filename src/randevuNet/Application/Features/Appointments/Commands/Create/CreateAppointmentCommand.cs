using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Domain.Enums;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;
using NArchitecture.Core.Mailing;
using System.Web;
using MimeKit;
using NArchitecture.Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Services.MailService;

namespace Application.Features.Appointments.Commands.Create;

public class CreateAppointmentCommand : IRequest<CreatedAppointmentResponse>, ISecuredRequest
{
    public required Guid PatientId { get; set; }
    public required int DoctorScheduleSlotId { get; set; }

    public string[] Roles => [Admin, Write, AppointmentsOperationClaims.Create];

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreatedAppointmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly AppointmentBusinessRules _appointmentBusinessRules;
        private readonly IMailService _mailService;
        public CreateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository,
                                         AppointmentBusinessRules appointmentBusinessRules, IMailService mailService)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _appointmentBusinessRules = appointmentBusinessRules;
            _mailService = mailService;
        }

        public async Task<CreatedAppointmentResponse> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Appointment appointment = _mapper.Map<Appointment>(request);
            var result = await _appointmentRepository.AddAsync(appointment);

            var createdAppointment = await _appointmentRepository.GetAsync(
                predicate: a => a.Id == result.Id,
                include: a => a.Include(a => a.Patient)
                .Include(a => a.DoctorScheduleSlot)
                .Include(a => a.DoctorScheduleSlot.Doctor)
                .Include(a => a.DoctorScheduleSlot.Doctor.DoctorTitle)
                .Include(a => a.DoctorScheduleSlot.Doctor.Hospital_Department)
                .Include(a => a.DoctorScheduleSlot.Doctor.Hospital_Department.Hospital)
                .Include(a => a.DoctorScheduleSlot.Doctor.Hospital_Department.Department));

            CreatedAppointmentResponse response = _mapper.Map<CreatedAppointmentResponse>(createdAppointment);

            //var xx = new AppointmentMailBase(options: new()
            //{
            //    DoctorTitle = response.DoctorTitle,
            //    DoctorFirstName = response.DoctorFirstName,
            //    DoctorLastName = response.DoctorLastName,

            //    PatientFirstName = response.PatientFirstName,
            //    PatientLastName = response.PatientLastName,

            //    HospitalName = response.HospitalName,
            //    DepartmentName = response.DepartmentName,

            //    Date = response.Date,
            //    StartTime = response.StartTime,
            //    EndTime = response.EndTime,
            //});

            //_mailService.SendMail(xx);

            var toEmailList = new List<MailboxAddress>
            {
               new (name: $"{response.PatientFirstName} {response.PatientLastName}",
                   address: response.PatientEmail)
            };

            _mailService.SendMail(new Mail
            {
                ToList = toEmailList,
                Subject = "Randevu Bilgilendirmesi",
                HtmlBody =@$"
<div style=""background-color:#2F2F75;color:white;padding:5px;border-radius:20px;margin-bottom:15px"">
<center><h3>RandevuNet | Randevu Bilgileri</h3></center>
</div>

<div style=""background-color:#2F2F75;color:white;padding: 20px;border-radius: 20px;"">
<div><b> Sn. {response.PatientFirstName} {response.PatientLastName}</b></div> 
<br />
Randevu bilgileriniz aþaðýda yer almaktadýr:
<br />
<br />
<div>
Hastane: <b>{response.HospitalName}</b>
<br />
Poliklinik: <b>{response.DepartmentName}</b>
<br />
Hekim: <b>{response.DoctorTitle} {response.DoctorFirstName} {response.DoctorLastName}</b>
<br />
Randevu Tarihi: <b>{response.Date}</b>
<br />
Randevu Saati: <b>{response.StartTime} - {response.EndTime}</b>
<br />
<br />
Lütfen belirtilen zamanda muayene için hazýr olunuz.
</div>
<br />
<small>{DateTime.Now.Year} RandevuNet</small>
</div>
"
 });

            return response;
        }
    }
}