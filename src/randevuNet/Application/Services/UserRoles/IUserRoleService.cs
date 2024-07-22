using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.UserRoles;

public interface IUserRoleService
{
    Task<UserRole?> GetAsync(
        Expression<Func<UserRole, bool>> predicate,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserRole>?> GetListAsync(
        Expression<Func<UserRole, bool>>? predicate = null,
        Func<IQueryable<UserRole>, IOrderedQueryable<UserRole>>? orderBy = null,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserRole> AddAsync(UserRole userRole);
    Task<UserRole> UpdateAsync(UserRole userRole);
    Task<UserRole> DeleteAsync(UserRole userRole, bool permanent = false);
}
