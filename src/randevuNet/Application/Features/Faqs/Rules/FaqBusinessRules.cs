using Application.Features.Faqs.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Faqs.Rules;

public class FaqBusinessRules : BaseBusinessRules
{
    private readonly IFaqRepository _faqRepository;
    private readonly ILocalizationService _localizationService;

    public FaqBusinessRules(IFaqRepository faqRepository, ILocalizationService localizationService)
    {
        _faqRepository = faqRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, FaqsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task FaqShouldExistWhenSelected(Faq? faq)
    {
        if (faq == null)
            await throwBusinessException(FaqsBusinessMessages.FaqNotExists);
    }

    public async Task FaqIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Faq? faq = await _faqRepository.GetAsync(
            predicate: f => f.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await FaqShouldExistWhenSelected(faq);
    }
}