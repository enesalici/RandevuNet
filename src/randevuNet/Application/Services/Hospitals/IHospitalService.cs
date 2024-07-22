using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Hospitals;

public interface IHospitalService
{
    Task<Hospital?> GetAsync(
        Expression<Func<Hospital, bool>> predicate,
        Func<IQueryable<Hospital>, IIncludableQueryable<Hospital, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Hospital>?> GetListAsync(
        Expression<Func<Hospital, bool>>? predicate = null,
        Func<IQueryable<Hospital>, IOrderedQueryable<Hospital>>? orderBy = null,
        Func<IQueryable<Hospital>, IIncludableQueryable<Hospital, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Hospital> AddAsync(Hospital hospital);
    Task<Hospital> UpdateAsync(Hospital hospital);
    Task<Hospital> DeleteAsync(Hospital hospital, bool permanent = false);
}
