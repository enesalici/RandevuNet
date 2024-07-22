using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using Domain.Enums;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;

namespace Application.Features.Appointments.Commands.Update;

public class UpdateAppointmentCommand : IRequest<UpdatedAppointmentResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required AppointmentStatus Status { get; set; }
    public required Guid PatientId { get; set; }
    public required int DoctorScheduleSlotId { get; set; }

    public string[] Roles => [Admin, Write, AppointmentsOperationClaims.Update];

    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand, UpdatedAppointmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly AppointmentBusinessRules _appointmentBusinessRules;

        public UpdateAppointmentCommandHandler(IMapper mapper, IAppointmentRepository appointmentRepository,
                                         AppointmentBusinessRules appointmentBusinessRules)
        {
            _mapper = mapper;
            _appointmentRepository = appointmentRepository;
            _appointmentBusinessRules = appointmentBusinessRules;
        }

        public async Task<UpdatedAppointmentResponse> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            Appointment? appointment = await _appointmentRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _appointmentBusinessRules.AppointmentShouldExistWhenSelected(appointment);
            appointment = _mapper.Map(request, appointment);

            await _appointmentRepository.UpdateAsync(appointment!);

            UpdatedAppointmentResponse response = _mapper.Map<UpdatedAppointmentResponse>(appointment);
            return response;
        }
    }
}