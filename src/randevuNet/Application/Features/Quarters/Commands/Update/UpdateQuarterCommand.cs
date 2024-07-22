using Application.Features.Quarters.Constants;
using Application.Features.Quarters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Quarters.Constants.QuartersOperationClaims;

namespace Application.Features.Quarters.Commands.Update;

public class UpdateQuarterCommand : IRequest<UpdatedQuarterResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int DistrictID { get; set; }

    public string[] Roles => [Admin, Write, QuartersOperationClaims.Update];

    public class UpdateQuarterCommandHandler : IRequestHandler<UpdateQuarterCommand, UpdatedQuarterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuarterRepository _quarterRepository;
        private readonly QuarterBusinessRules _quarterBusinessRules;

        public UpdateQuarterCommandHandler(IMapper mapper, IQuarterRepository quarterRepository,
                                         QuarterBusinessRules quarterBusinessRules)
        {
            _mapper = mapper;
            _quarterRepository = quarterRepository;
            _quarterBusinessRules = quarterBusinessRules;
        }

        public async Task<UpdatedQuarterResponse> Handle(UpdateQuarterCommand request, CancellationToken cancellationToken)
        {
            Quarter? quarter = await _quarterRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken);
            await _quarterBusinessRules.QuarterShouldExistWhenSelected(quarter);
            quarter = _mapper.Map(request, quarter);

            await _quarterRepository.UpdateAsync(quarter!);

            UpdatedQuarterResponse response = _mapper.Map<UpdatedQuarterResponse>(quarter);
            return response;
        }
    }
}