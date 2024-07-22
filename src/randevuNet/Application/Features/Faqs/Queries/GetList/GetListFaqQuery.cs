using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Faqs.Queries.GetList;

public class GetListFaqQuery : IRequest<GetListResponse<GetListFaqListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListFaqQueryHandler : IRequestHandler<GetListFaqQuery, GetListResponse<GetListFaqListItemDto>>
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMapper _mapper;

        public GetListFaqQueryHandler(IFaqRepository faqRepository, IMapper mapper)
        {
            _faqRepository = faqRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListFaqListItemDto>> Handle(GetListFaqQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Faq> faqs = await _faqRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListFaqListItemDto> response = _mapper.Map<GetListResponse<GetListFaqListItemDto>>(faqs);
            return response;
        }
    }
}