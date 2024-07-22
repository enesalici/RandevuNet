using Application.Features.AppointmentReports.Constants;
using Application.Features.AppointmentReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AppointmentReports.Constants.AppointmentReportsOperationClaims;

namespace Application.Features.AppointmentReports.Commands.Create;

public class CreateAppointmentReportCommand : IRequest<CreatedAppointmentReportResponse>, ISecuredRequest
{
    public required string Title { get; set; }
    public required string Detail { get; set; }
    public required Guid AppointmentID { get; set; }

    public string[] Roles => [Admin, Write, AppointmentReportsOperationClaims.Create];

    public class CreateAppointmentReportCommandHandler : IRequestHandler<CreateAppointmentReportCommand, CreatedAppointmentReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentReportRepository _appointmentReportRepository;
        private readonly AppointmentReportBusinessRules _appointmentReportBusinessRules;

        public CreateAppointmentReportCommandHandler(IMapper mapper, IAppointmentReportRepository appointmentReportRepository,
                                         AppointmentReportBusinessRules appointmentReportBusinessRules)
        {
            _mapper = mapper;
            _appointmentReportRepository = appointmentReportRepository;
            _appointmentReportBusinessRules = appointmentReportBusinessRules;
        }

        public async Task<CreatedAppointmentReportResponse> Handle(CreateAppointmentReportCommand request, CancellationToken cancellationToken)
        {
            AppointmentReport appointmentReport = _mapper.Map<AppointmentReport>(request);

            await _appointmentReportRepository.AddAsync(appointmentReport);

            CreatedAppointmentReportResponse response = _mapper.Map<CreatedAppointmentReportResponse>(appointmentReport);
            return response;
        }
    }
}