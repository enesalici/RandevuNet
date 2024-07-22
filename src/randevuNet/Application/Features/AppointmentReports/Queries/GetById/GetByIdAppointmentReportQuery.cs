using Application.Features.AppointmentReports.Constants;
using Application.Features.AppointmentReports.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AppointmentReports.Constants.AppointmentReportsOperationClaims;

namespace Application.Features.AppointmentReports.Queries.GetById;

public class GetByIdAppointmentReportQuery : IRequest<GetByIdAppointmentReportResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAppointmentReportQueryHandler : IRequestHandler<GetByIdAppointmentReportQuery, GetByIdAppointmentReportResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentReportRepository _appointmentReportRepository;
        private readonly AppointmentReportBusinessRules _appointmentReportBusinessRules;

        public GetByIdAppointmentReportQueryHandler(IMapper mapper, IAppointmentReportRepository appointmentReportRepository, AppointmentReportBusinessRules appointmentReportBusinessRules)
        {
            _mapper = mapper;
            _appointmentReportRepository = appointmentReportRepository;
            _appointmentReportBusinessRules = appointmentReportBusinessRules;
        }

        public async Task<GetByIdAppointmentReportResponse> Handle(GetByIdAppointmentReportQuery request, CancellationToken cancellationToken)
        {
            AppointmentReport? appointmentReport = await _appointmentReportRepository.GetAsync(predicate: ar => ar.Id == request.Id, cancellationToken: cancellationToken);
            await _appointmentReportBusinessRules.AppointmentReportShouldExistWhenSelected(appointmentReport);

            GetByIdAppointmentReportResponse response = _mapper.Map<GetByIdAppointmentReportResponse>(appointmentReport);
            return response;
        }
    }
}