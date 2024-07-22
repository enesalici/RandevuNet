using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DoctorTitles;

public interface IDoctorTitleService
{
    Task<DoctorTitle?> GetAsync(
        Expression<Func<DoctorTitle, bool>> predicate,
        Func<IQueryable<DoctorTitle>, IIncludableQueryable<DoctorTitle, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DoctorTitle>?> GetListAsync(
        Expression<Func<DoctorTitle, bool>>? predicate = null,
        Func<IQueryable<DoctorTitle>, IOrderedQueryable<DoctorTitle>>? orderBy = null,
        Func<IQueryable<DoctorTitle>, IIncludableQueryable<DoctorTitle, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DoctorTitle> AddAsync(DoctorTitle doctorTitle);
    Task<DoctorTitle> UpdateAsync(DoctorTitle doctorTitle);
    Task<DoctorTitle> DeleteAsync(DoctorTitle doctorTitle, bool permanent = false);
}
