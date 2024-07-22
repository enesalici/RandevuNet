using Application.Features.Feedbacks.Constants;
using Application.Features.Feedbacks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Commands.Update;

public class UpdateFeedbackCommand : IRequest<UpdatedFeedbackResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Message { get; set; }
    public required Guid UserID { get; set; }

    public string[] Roles => [Admin, Write, FeedbacksOperationClaims.Update];

    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, UpdatedFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly FeedbackBusinessRules _feedbackBusinessRules;

        public UpdateFeedbackCommandHandler(IMapper mapper, IFeedbackRepository feedbackRepository,
                                         FeedbackBusinessRules feedbackBusinessRules)
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
            _feedbackBusinessRules = feedbackBusinessRules;
        }

        public async Task<UpdatedFeedbackResponse> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            Feedback? feedback = await _feedbackRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _feedbackBusinessRules.FeedbackShouldExistWhenSelected(feedback);
            feedback = _mapper.Map(request, feedback);

            await _feedbackRepository.UpdateAsync(feedback!);

            UpdatedFeedbackResponse response = _mapper.Map<UpdatedFeedbackResponse>(feedback);
            return response;
        }
    }
}