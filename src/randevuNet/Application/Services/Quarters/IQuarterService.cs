using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Quarters;

public interface IQuarterService
{
    Task<Quarter?> GetAsync(
        Expression<Func<Quarter, bool>> predicate,
        Func<IQueryable<Quarter>, IIncludableQueryable<Quarter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Quarter>?> GetListAsync(
        Expression<Func<Quarter, bool>>? predicate = null,
        Func<IQueryable<Quarter>, IOrderedQueryable<Quarter>>? orderBy = null,
        Func<IQueryable<Quarter>, IIncludableQueryable<Quarter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Quarter> AddAsync(Quarter quarter);
    Task<Quarter> UpdateAsync(Quarter quarter);
    Task<Quarter> DeleteAsync(Quarter quarter, bool permanent = false);
}
