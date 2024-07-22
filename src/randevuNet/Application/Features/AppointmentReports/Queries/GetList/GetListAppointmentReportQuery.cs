using Application.Features.AppointmentReports.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AppointmentReports.Constants.AppointmentReportsOperationClaims;

namespace Application.Features.AppointmentReports.Queries.GetList;

public class GetListAppointmentReportQuery : IRequest<GetListResponse<GetListAppointmentReportListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListAppointmentReportQueryHandler : IRequestHandler<GetListAppointmentReportQuery, GetListResponse<GetListAppointmentReportListItemDto>>
    {
        private readonly IAppointmentReportRepository _appointmentReportRepository;
        private readonly IMapper _mapper;

        public GetListAppointmentReportQueryHandler(IAppointmentReportRepository appointmentReportRepository, IMapper mapper)
        {
            _appointmentReportRepository = appointmentReportRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAppointmentReportListItemDto>> Handle(GetListAppointmentReportQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AppointmentReport> appointmentReports = await _appointmentReportRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAppointmentReportListItemDto> response = _mapper.Map<GetListResponse<GetListAppointmentReportListItemDto>>(appointmentReports);
            return response;
        }
    }
}