using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HospitalDepartments;

public interface IHospitalDepartmentService
{
    Task<Hospital_Department?> GetAsync(
        Expression<Func<Hospital_Department, bool>> predicate,
        Func<IQueryable<Hospital_Department>, IIncludableQueryable<Hospital_Department, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Hospital_Department>?> GetListAsync(
        Expression<Func<Hospital_Department, bool>>? predicate = null,
        Func<IQueryable<Hospital_Department>, IOrderedQueryable<Hospital_Department>>? orderBy = null,
        Func<IQueryable<Hospital_Department>, IIncludableQueryable<Hospital_Department, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Hospital_Department> AddAsync(Hospital_Department hospitalDepartment);
    Task<Hospital_Department> UpdateAsync(Hospital_Department hospitalDepartment);
    Task<Hospital_Department> DeleteAsync(Hospital_Department hospitalDepartment, bool permanent = false);
}
