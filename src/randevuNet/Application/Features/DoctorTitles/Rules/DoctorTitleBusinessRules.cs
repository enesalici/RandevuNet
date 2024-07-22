using Application.Features.DoctorTitles.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DoctorTitles.Rules;

public class DoctorTitleBusinessRules : BaseBusinessRules
{
    private readonly IDoctorTitleRepository _doctorTitleRepository;
    private readonly ILocalizationService _localizationService;

    public DoctorTitleBusinessRules(IDoctorTitleRepository doctorTitleRepository, ILocalizationService localizationService)
    {
        _doctorTitleRepository = doctorTitleRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DoctorTitlesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DoctorTitleShouldExistWhenSelected(DoctorTitle? doctorTitle)
    {
        if (doctorTitle == null)
            await throwBusinessException(DoctorTitlesBusinessMessages.DoctorTitleNotExists);
    }

    public async Task DoctorTitleIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        DoctorTitle? doctorTitle = await _doctorTitleRepository.GetAsync(
            predicate: dt => dt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DoctorTitleShouldExistWhenSelected(doctorTitle);
    }
}