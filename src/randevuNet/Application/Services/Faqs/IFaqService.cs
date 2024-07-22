using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Faqs;

public interface IFaqService
{
    Task<Faq?> GetAsync(
        Expression<Func<Faq, bool>> predicate,
        Func<IQueryable<Faq>, IIncludableQueryable<Faq, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Faq>?> GetListAsync(
        Expression<Func<Faq, bool>>? predicate = null,
        Func<IQueryable<Faq>, IOrderedQueryable<Faq>>? orderBy = null,
        Func<IQueryable<Faq>, IIncludableQueryable<Faq, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Faq> AddAsync(Faq faq);
    Task<Faq> UpdateAsync(Faq faq);
    Task<Faq> DeleteAsync(Faq faq, bool permanent = false);
}
