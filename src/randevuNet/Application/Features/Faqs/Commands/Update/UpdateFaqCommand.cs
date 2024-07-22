using Application.Features.Faqs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Faqs.Commands.Update;

public class UpdateFaqCommand : IRequest<UpdatedFaqResponse>
{
    public int Id { get; set; }
    public required string Question { get; set; }
    public required string Answer { get; set; }

    public class UpdateFaqCommandHandler : IRequestHandler<UpdateFaqCommand, UpdatedFaqResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFaqRepository _faqRepository;
        private readonly FaqBusinessRules _faqBusinessRules;

        public UpdateFaqCommandHandler(IMapper mapper, IFaqRepository faqRepository,
                                         FaqBusinessRules faqBusinessRules)
        {
            _mapper = mapper;
            _faqRepository = faqRepository;
            _faqBusinessRules = faqBusinessRules;
        }

        public async Task<UpdatedFaqResponse> Handle(UpdateFaqCommand request, CancellationToken cancellationToken)
        {
            Faq? faq = await _faqRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            await _faqBusinessRules.FaqShouldExistWhenSelected(faq);
            faq = _mapper.Map(request, faq);

            await _faqRepository.UpdateAsync(faq!);

            UpdatedFaqResponse response = _mapper.Map<UpdatedFaqResponse>(faq);
            return response;
        }
    }
}