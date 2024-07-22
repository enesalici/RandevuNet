using Application.Features.AppointmentReports.Constants;
using Application.Features.AppointmentReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AppointmentReports.Constants.AppointmentReportsOperationClaims;

namespace Application.Features.AppointmentReports.Commands.Update;

public class UpdateAppointmentReportCommand : IRequest<UpdatedAppointmentReportResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Detail { get; set; }
    public required Guid AppointmentID { get; set; }

    public string[] Roles => [Admin, Write, AppointmentReportsOperationClaims.Update];

    public class UpdateAppointmentReportCommandHandler : IRequestHandler<UpdateAppointmentReportCommand, UpdatedAppointmentReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentReportRepository _appointmentReportRepository;
        private readonly AppointmentReportBusinessRules _appointmentReportBusinessRules;

        public UpdateAppointmentReportCommandHandler(IMapper mapper, IAppointmentReportRepository appointmentReportRepository,
                                         AppointmentReportBusinessRules appointmentReportBusinessRules)
        {
            _mapper = mapper;
            _appointmentReportRepository = appointmentReportRepository;
            _appointmentReportBusinessRules = appointmentReportBusinessRules;
        }

        public async Task<UpdatedAppointmentReportResponse> Handle(UpdateAppointmentReportCommand request, CancellationToken cancellationToken)
        {
            AppointmentReport? appointmentReport = await _appointmentReportRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _appointmentReportBusinessRules.AppointmentReportShouldExistWhenSelected(appointmentReport);
            appointmentReport = _mapper.Map(request, appointmentReport);

            await _appointmentReportRepository.UpdateAsync(appointmentReport!);

            UpdatedAppointmentReportResponse response = _mapper.Map<UpdatedAppointmentReportResponse>(appointmentReport);
            return response;
        }
    }
}