using Application.Features.Quarters.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Quarters.Constants.QuartersOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Quarters.Queries.GetList;

public class GetListQuarterQuery : IRequest<GetListResponse<GetListQuarterListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListQuarterQueryHandler : IRequestHandler<GetListQuarterQuery, GetListResponse<GetListQuarterListItemDto>>
    {
        private readonly IQuarterRepository _quarterRepository;
        private readonly IMapper _mapper;

        public GetListQuarterQueryHandler(IQuarterRepository quarterRepository, IMapper mapper)
        {
            _quarterRepository = quarterRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListQuarterListItemDto>> Handle(GetListQuarterQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Quarter> quarters = await _quarterRepository.GetListAsync(
                include: q => q.Include(q => q.District).Include(q => q.District.City).Include(q => q.District.City.Country),
                orderBy: q => q.OrderBy(q => q.Name).OrderBy(q => q.District.City.Name).OrderBy(q => q.District.City.Country.Name),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListQuarterListItemDto> response = _mapper.Map<GetListResponse<GetListQuarterListItemDto>>(quarters);
            return response;
        }
    }
}