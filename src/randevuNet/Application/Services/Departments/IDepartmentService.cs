using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Departments;

public interface IDepartmentService
{
    Task<Department?> GetAsync(
        Expression<Func<Department, bool>> predicate,
        Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Department>?> GetListAsync(
        Expression<Func<Department, bool>>? predicate = null,
        Func<IQueryable<Department>, IOrderedQueryable<Department>>? orderBy = null,
        Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Department> AddAsync(Department department);
    Task<Department> UpdateAsync(Department department);
    Task<Department> DeleteAsync(Department department, bool permanent = false);
}
