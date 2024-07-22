using Application.Features.Feedbacks.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Feedbacks.Constants.FeedbacksOperationClaims;

namespace Application.Features.Feedbacks.Queries.GetList;

public class GetListFeedbackQuery : IRequest<GetListResponse<GetListFeedbackListItemDto>>, ISecuredRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetListFeedbackQueryHandler : IRequestHandler<GetListFeedbackQuery, GetListResponse<GetListFeedbackListItemDto>>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public GetListFeedbackQueryHandler(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFeedbackListItemDto>> Handle(GetListFeedbackQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Feedback> feedbacks = await _feedbackRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFeedbackListItemDto> response = _mapper.Map<GetListResponse<GetListFeedbackListItemDto>>(feedbacks);
            return response;
        }
    }
}