using Application.Features.HospitalDepartments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.HospitalDepartments.Rules;

public class HospitalDepartmentBusinessRules : BaseBusinessRules
{
    private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
    private readonly ILocalizationService _localizationService;

    public HospitalDepartmentBusinessRules(IHospitalDepartmentRepository hospitalDepartmentRepository, ILocalizationService localizationService)
    {
        _hospitalDepartmentRepository = hospitalDepartmentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, HospitalDepartmentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task HospitalDepartmentShouldExistWhenSelected(Hospital_Department? hospitalDepartment)
    {
        if (hospitalDepartment == null)
            await throwBusinessException(HospitalDepartmentsBusinessMessages.HospitalDepartmentNotExists);
    }

    public async Task HospitalDepartmentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Hospital_Department? hospitalDepartment = await _hospitalDepartmentRepository.GetAsync(
            predicate: hd => hd.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await HospitalDepartmentShouldExistWhenSelected(hospitalDepartment);
    }
}