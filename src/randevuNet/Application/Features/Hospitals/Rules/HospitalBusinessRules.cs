using Application.Features.Hospitals.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Hospitals.Rules;

public class HospitalBusinessRules : BaseBusinessRules
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly ILocalizationService _localizationService;

    public HospitalBusinessRules(IHospitalRepository hospitalRepository, ILocalizationService localizationService)
    {
        _hospitalRepository = hospitalRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, HospitalsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task HospitalShouldExistWhenSelected(Hospital? hospital)
    {
        if (hospital == null)
            await throwBusinessException(HospitalsBusinessMessages.HospitalNotExists);
    }

    public async Task HospitalIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Hospital? hospital = await _hospitalRepository.GetAsync(
            predicate: h => h.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await HospitalShouldExistWhenSelected(hospital);
    }
}