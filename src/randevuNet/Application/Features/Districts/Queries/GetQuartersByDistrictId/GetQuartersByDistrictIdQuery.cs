using Application.Features.Districts.Constants;
using Application.Features.Districts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Districts.Constants.DistrictsOperationClaims;

namespace Application.Features.Districts.Queries.GetQuartersByDistrictId;

public class GetQuartersByDistrictIdQuery : IRequest<GetListResponse<GetQuartersByDistrictIdListItemDto>>, ISecuredRequest
{
    public int DistrictId { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles => [Admin, Read, DistrictsOperationClaims.GetQuartersByDistrictId];
    
    public class GetQuartersByDistrictIdQueryHandler : IRequestHandler<GetQuartersByDistrictIdQuery, GetListResponse<GetQuartersByDistrictIdListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly DistrictBusinessRules _districtBusinessRules;
        private readonly IQuarterRepository _quarterRepository;
        public GetQuartersByDistrictIdQueryHandler(IMapper mapper, DistrictBusinessRules districtBusinessRules, IQuarterRepository quarterRepository)
        {
            _mapper = mapper;
            _districtBusinessRules = districtBusinessRules;
            _quarterRepository = quarterRepository;
        }

        public async Task<GetListResponse<GetQuartersByDistrictIdListItemDto>> Handle(GetQuartersByDistrictIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Quarter> quarters = await _quarterRepository.GetListAsync(
               predicate: c => c.DistrictID == request.DistrictId,
               include: c => c.Include(c => c.District).Include(c => c.District.City).Include(c => c.District.City.Country),
               orderBy: c => c.OrderBy(c => c.Name),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken);

            GetListResponse<GetQuartersByDistrictIdListItemDto> response = _mapper.Map<GetListResponse<GetQuartersByDistrictIdListItemDto>>(quarters);
            return response;
        }
    }
}
