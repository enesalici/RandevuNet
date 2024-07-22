using Application.Features.Cities.Constants;
using Application.Features.Cities.Rules;
using AutoMapper;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Cities.Constants.CitiesOperationClaims;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Application.Requests;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Queries.GetDistrictsByCityId;

public class GetDistrictsByCityIdQuery : IRequest<GetListResponse<GetDistrictsByCityIdListItemDto>>, ISecuredRequest
{
    public int CityId { get; set; }
    public PageRequest PageRequest { get; set; }
    public string[] Roles => [Admin, Read, CitiesOperationClaims.GetDistrictsByCityId];
    
    public class GetDistrictsByCityIdQueryHandler : IRequestHandler<GetDistrictsByCityIdQuery, GetListResponse<GetDistrictsByCityIdListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly CityBusinessRules _cityBusinessRules;
        private readonly IDistrictRepository _districtRepository;
        public GetDistrictsByCityIdQueryHandler(IMapper mapper, CityBusinessRules cityBusinessRules, IDistrictRepository districtRepository)
        {
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
            _districtRepository = districtRepository;
        }

        public async Task<GetListResponse<GetDistrictsByCityIdListItemDto>> Handle(GetDistrictsByCityIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<District> districts = await _districtRepository.GetListAsync(
              predicate: d => d.CityID == request.CityId,
              include: d => d.Include(d => d.City).Include(d => d.City.Country),
              orderBy: d => d.OrderBy(d => d.Name),
              index: request.PageRequest.PageIndex,
              size: request.PageRequest.PageSize,
              cancellationToken: cancellationToken
          );

            GetListResponse<GetDistrictsByCityIdListItemDto> response = _mapper.Map<GetListResponse<GetDistrictsByCityIdListItemDto>>(districts);
            return response;
        }
    }
}
