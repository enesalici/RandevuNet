using Application.Features.Countries.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Countries.Rules;

public class CountryBusinessRules : BaseBusinessRules
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILocalizationService _localizationService;

    public CountryBusinessRules(ICountryRepository countryRepository, ILocalizationService localizationService)
    {
        _countryRepository = countryRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, CountriesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task CountryShouldExistWhenSelected(Country? country)
    {
        if (country == null)
            await throwBusinessException(CountriesBusinessMessages.CountryNotExists);
    }

    public async Task CountryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Country? country = await _countryRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CountryShouldExistWhenSelected(country);
    }
}