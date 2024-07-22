using Application.Features.Quarters.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Quarters.Rules;

public class QuarterBusinessRules : BaseBusinessRules
{
    private readonly IQuarterRepository _quarterRepository;
    private readonly ILocalizationService _localizationService;

    public QuarterBusinessRules(IQuarterRepository quarterRepository, ILocalizationService localizationService)
    {
        _quarterRepository = quarterRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, QuartersBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task QuarterShouldExistWhenSelected(Quarter? quarter)
    {
        if (quarter == null)
            await throwBusinessException(QuartersBusinessMessages.QuarterNotExists);
    }

    public async Task QuarterIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Quarter? quarter = await _quarterRepository.GetAsync(
            predicate: q => q.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await QuarterShouldExistWhenSelected(quarter);
    }
}