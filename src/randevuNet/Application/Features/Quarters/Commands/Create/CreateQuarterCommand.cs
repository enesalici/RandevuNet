using Application.Features.Quarters.Constants;
using Application.Features.Quarters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Quarters.Constants.QuartersOperationClaims;

namespace Application.Features.Quarters.Commands.Create;

public class CreateQuarterCommand : IRequest<CreatedQuarterResponse>, ISecuredRequest
{
    public required string Name { get; set; }
    public required int DistrictID { get; set; }

    public string[] Roles => [Admin, Write, QuartersOperationClaims.Create];

    public class CreateQuarterCommandHandler : IRequestHandler<CreateQuarterCommand, CreatedQuarterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuarterRepository _quarterRepository;
        private readonly QuarterBusinessRules _quarterBusinessRules;

        public CreateQuarterCommandHandler(IMapper mapper, IQuarterRepository quarterRepository,
                                         QuarterBusinessRules quarterBusinessRules)
        {
            _mapper = mapper;
            _quarterRepository = quarterRepository;
            _quarterBusinessRules = quarterBusinessRules;
        }

        public async Task<CreatedQuarterResponse> Handle(CreateQuarterCommand request, CancellationToken cancellationToken)
        {
            Quarter quarter = _mapper.Map<Quarter>(request);

            await _quarterRepository.AddAsync(quarter);

            CreatedQuarterResponse response = _mapper.Map<CreatedQuarterResponse>(quarter);
            return response;
        }
    }
}