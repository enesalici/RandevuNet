using Application.Features.HospitalAddresses.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.HospitalAddresses.Rules;

public class HospitalAddressBusinessRules : BaseBusinessRules
{
    private readonly IHospitalAddressRepository _hospitalAddressRepository;
    private readonly ILocalizationService _localizationService;

    public HospitalAddressBusinessRules(IHospitalAddressRepository hospitalAddressRepository, ILocalizationService localizationService)
    {
        _hospitalAddressRepository = hospitalAddressRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, HospitalAddressesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task HospitalAddressShouldExistWhenSelected(HospitalAddress? hospitalAddress)
    {
        if (hospitalAddress == null)
            await throwBusinessException(HospitalAddressesBusinessMessages.HospitalAddressNotExists);
    }

    public async Task HospitalAddressIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        HospitalAddress? hospitalAddress = await _hospitalAddressRepository.GetAsync(
            predicate: ha => ha.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await HospitalAddressShouldExistWhenSelected(hospitalAddress);
    }
}