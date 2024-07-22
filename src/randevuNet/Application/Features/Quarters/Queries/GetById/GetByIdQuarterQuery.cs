using Application.Features.Quarters.Constants;
using Application.Features.Quarters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Quarters.Constants.QuartersOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Quarters.Queries.GetById;

public class GetByIdQuarterQuery : IRequest<GetByIdQuarterResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdQuarterQueryHandler : IRequestHandler<GetByIdQuarterQuery, GetByIdQuarterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuarterRepository _quarterRepository;
        private readonly QuarterBusinessRules _quarterBusinessRules;

        public GetByIdQuarterQueryHandler(IMapper mapper, IQuarterRepository quarterRepository, QuarterBusinessRules quarterBusinessRules)
        {
            _mapper = mapper;
            _quarterRepository = quarterRepository;
            _quarterBusinessRules = quarterBusinessRules;
        }

        public async Task<GetByIdQuarterResponse> Handle(GetByIdQuarterQuery request, CancellationToken cancellationToken)
        {
            Quarter? quarter = await _quarterRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken,
                 include: q => q.Include(q => q.District).Include(q => q.District.City).Include(q => q.District.City.Country));
            await _quarterBusinessRules.QuarterShouldExistWhenSelected(quarter);

            GetByIdQuarterResponse response = _mapper.Map<GetByIdQuarterResponse>(quarter);
            return response;
        }
    }
}