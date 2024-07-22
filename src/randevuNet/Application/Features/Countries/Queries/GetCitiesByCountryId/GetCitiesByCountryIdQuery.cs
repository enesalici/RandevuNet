using Application.Features.Countries.Constants;
using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using static Application.Features.Countries.Constants.CountriesOperationClaims;

namespace Application.Features.Countries.Queries.GetCitiesByCountryId;

public class GetCitiesByCountryIdQuery : IRequest<GetListResponse<GetCitiesByCountryIdListItemDto>>, ISecuredRequest
{
    public int CountryId { get; set; }
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read, CountriesOperationClaims.GetCitiesByCountryId];
    
    public class GetCitiesByCountryIdQueryHandler : IRequestHandler<GetCitiesByCountryIdQuery, GetListResponse<GetCitiesByCountryIdListItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly CountryBusinessRules _countryBusinessRules;
        private readonly ICityRepository _cityRepository;
        public GetCitiesByCountryIdQueryHandler(IMapper mapper, CountryBusinessRules countryBusinessRules, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _countryBusinessRules = countryBusinessRules;
            _cityRepository = cityRepository;
        }

        public async Task<GetListResponse<GetCitiesByCountryIdListItemDto>> Handle(GetCitiesByCountryIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListAsync(
               predicate: c => c.CountryID == request.CountryId,
               include: c => c.Include(c => c.Country),
               orderBy: c => c.OrderBy(c => c.Name),
               index: request.PageRequest.PageIndex,
               size: request.PageRequest.PageSize,
               cancellationToken: cancellationToken
           );

            GetListResponse<GetCitiesByCountryIdListItemDto> response = _mapper.Map<GetListResponse<GetCitiesByCountryIdListItemDto>>(cities);
            return response;
        }
    }
}
