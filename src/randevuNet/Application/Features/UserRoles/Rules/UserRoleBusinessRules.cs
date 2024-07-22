using Application.Features.UserRoles.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.UserRoles.Rules;

public class UserRoleBusinessRules : BaseBusinessRules
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly ILocalizationService _localizationService;

    public UserRoleBusinessRules(IUserRoleRepository userRoleRepository, ILocalizationService localizationService)
    {
        _userRoleRepository = userRoleRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, UserRolesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task UserRoleShouldExistWhenSelected(UserRole? userRole)
    {
        if (userRole == null)
            await throwBusinessException(UserRolesBusinessMessages.UserRoleNotExists);
    }

    public async Task UserRoleIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        UserRole? userRole = await _userRoleRepository.GetAsync(
            predicate: ur => ur.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserRoleShouldExistWhenSelected(userRole);
    }
}