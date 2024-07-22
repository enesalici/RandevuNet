using Application.Features.Departments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Departments.Rules;

public class DepartmentBusinessRules : BaseBusinessRules
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ILocalizationService _localizationService;

    public DepartmentBusinessRules(IDepartmentRepository departmentRepository, ILocalizationService localizationService)
    {
        _departmentRepository = departmentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DepartmentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DepartmentShouldExistWhenSelected(Department? department)
    {
        if (department == null)
            await throwBusinessException(DepartmentsBusinessMessages.DepartmentNotExists);
    }

    public async Task DepartmentIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Department? department = await _departmentRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DepartmentShouldExistWhenSelected(department);
    }
}