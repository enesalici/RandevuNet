using Application.Features.Quarters.Constants;
using Application.Features.Quarters.Constants;
using Application.Features.Quarters.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Quarters.Constants.QuartersOperationClaims;

namespace Application.Features.Quarters.Commands.Delete;

public class DeleteQuarterCommand : IRequest<DeletedQuarterResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => [Admin, Write, QuartersOperationClaims.Delete];

    public class DeleteQuarterCommandHandler : IRequestHandler<DeleteQuarterCommand, DeletedQuarterResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuarterRepository _quarterRepository;
        private readonly QuarterBusinessRules _quarterBusinessRules;

        public DeleteQuarterCommandHandler(IMapper mapper, IQuarterRepository quarterRepository,
                                         QuarterBusinessRules quarterBusinessRules)
        {
            _mapper = mapper;
            _quarterRepository = quarterRepository;
            _quarterBusinessRules = quarterBusinessRules;
        }

        public async Task<DeletedQuarterResponse> Handle(DeleteQuarterCommand request, CancellationToken cancellationToken)
        {
            Quarter? quarter = await _quarterRepository.GetAsync(predicate: q => q.Id == request.Id, cancellationToken: cancellationToken);
            await _quarterBusinessRules.QuarterShouldExistWhenSelected(quarter);

            await _quarterRepository.DeleteAsync(quarter!);

            DeletedQuarterResponse response = _mapper.Map<DeletedQuarterResponse>(quarter);
            return response;
        }
    }
}