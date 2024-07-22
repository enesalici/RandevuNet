using Application.Features.Appointments.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Appointments.Constants.AppointmentsOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Appointments.Queries.GetList;

public class GetListAppointmentQuery : IRequest<GetListResponse<GetListAppointmentListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAppointmentQueryHandler : IRequestHandler<GetListAppointmentQuery, GetListResponse<GetListAppointmentListItemDto>>
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public GetListAppointmentQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAppointmentListItemDto>> Handle(GetListAppointmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Appointment> appointments = await _appointmentRepository.GetListAsync(
                include: a => a.Include(a => a.Patient)
                .Include(a => a.DoctorScheduleSlot)
                .Include(a => a.DoctorScheduleSlot.Doctor)
                .Include(a => a.DoctorScheduleSlot.Doctor.DoctorTitle)
                .Include(a => a.DoctorScheduleSlot.Doctor.Hospital_Department)
                .Include(a => a.DoctorScheduleSlot.Doctor.Hospital_Department.Hospital)
                .Include(a => a.DoctorScheduleSlot.Doctor.Hospital_Department.Department),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAppointmentListItemDto> response = _mapper.Map<GetListResponse<GetListAppointmentListItemDto>>(appointments);
            return response;
        }
    }
}