using Application.Features.UserRoles.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserRoles;

public class UserRoleManager : IUserRoleService
{
    private readonly IUserRoleRepository _userRoleRepository;
    private readonly UserRoleBusinessRules _userRoleBusinessRules;

    public UserRoleManager(IUserRoleRepository userRoleRepository, UserRoleBusinessRules userRoleBusinessRules)
    {
        _userRoleRepository = userRoleRepository;
        _userRoleBusinessRules = userRoleBusinessRules;
    }

    public async Task<UserRole?> GetAsync(
        Expression<Func<UserRole, bool>> predicate,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        UserRole? userRole = await _userRoleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return userRole;
    }

    public async Task<IPaginate<UserRole>?> GetListAsync(
        Expression<Func<UserRole, bool>>? predicate = null,
        Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>>? orderBy = null,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<UserRole> userRoleList = await _userRoleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userRoleList;
    }

    public async Task<UserRole> AddAsync(UserRole userRole)
    {
        UserRole addedUserRole = await _userRoleRepository.AddAsync(userRole);

        return addedUserRole;
    }

    public async Task<UserRole> UpdateAsync(UserRole userRole)
    {
        UserRole updatedUserRole = await _userRoleRepository.UpdateAsync(userRole);

        return updatedUserRole;
    }

    public async Task<UserRole> DeleteAsync(UserRole userRole, bool permanent = false)
    {
        UserRole deletedUserRole = await _userRoleRepository.DeleteAsync(userRole);

        return deletedUserRole;
    }
}
