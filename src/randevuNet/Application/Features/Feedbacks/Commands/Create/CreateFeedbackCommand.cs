using Application.Features.Feedbacks.Constants;
using Application.Features.Feedbacks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Commands.Create;

public class CreateFeedbackCommand : IRequest<CreatedFeedbackResponse>, ISecuredRequest
{
    public required string Title { get; set; }
    public required string Message { get; set; }
    public required Guid UserID { get; set; }

    public string[] Roles => [Admin, Write, FeedbacksOperationClaims.Create];

    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, CreatedFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly FeedbackBusinessRules _feedbackBusinessRules;

        public CreateFeedbackCommandHandler(IMapper mapper, IFeedbackRepository feedbackRepository,
                                         FeedbackBusinessRules feedbackBusinessRules)
        {
            _mapper = mapper;
            _feedbackRepository = feedbackRepository;
            _feedbackBusinessRules = feedbackBusinessRules;
        }

        public async Task<CreatedFeedbackResponse> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            Feedback feedback = _mapper.Map<Feedback>(request);

            await _feedbackRepository.AddAsync(feedback);

            CreatedFeedbackResponse response = _mapper.Map<CreatedFeedbackResponse>(feedback);
            return response;
        }
    }
}