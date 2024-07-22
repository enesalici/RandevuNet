using Application.Features.AppointmentReports.Constants;
using Application.Features.AppointmentReports.Constants;
using Application.Features.AppointmentReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AppointmentReports.Constants.AppointmentReportsOperationClaims;

namespace Application.Features.AppointmentReports.Commands.Delete;

public class DeleteAppointmentReportCommand : IRequest<DeletedAppointmentReportResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, AppointmentReportsOperationClaims.Delete];

    public class DeleteAppointmentReportCommandHandler : IRequestHandler<DeleteAppointmentReportCommand, DeletedAppointmentReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentReportRepository _appointmentReportRepository;
        private readonly AppointmentReportBusinessRules _appointmentReportBusinessRules;

        public DeleteAppointmentReportCommandHandler(IMapper mapper, IAppointmentReportRepository appointmentReportRepository,
                                         AppointmentReportBusinessRules appointmentReportBusinessRules)
        {
            _mapper = mapper;
            _appointmentReportRepository = appointmentReportRepository;
            _appointmentReportBusinessRules = appointmentReportBusinessRules;
        }

        public async Task<DeletedAppointmentReportResponse> Handle(DeleteAppointmentReportCommand request, CancellationToken cancellationToken)
        {
            AppointmentReport? appointmentReport = await _appointmentReportRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _appointmentReportBusinessRules.AppointmentReportShouldExistWhenSelected(appointmentReport);

            await _appointmentReportRepository.DeleteAsync(appointmentReport!);

            DeletedAppointmentReportResponse response = _mapper.Map<DeletedAppointmentReportResponse>(appointmentReport);
            return response;
        }
    }
}