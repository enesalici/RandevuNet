using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HospitalAddresses;

public interface IHospitalAddressService
{
    Task<HospitalAddress?> GetAsync(
        Expression<Func<HospitalAddress, bool>> predicate,
        Func<IQueryable<HospitalAddress>, IIncludableQueryable<HospitalAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<HospitalAddress>?> GetListAsync(
        Expression<Func<HospitalAddress, bool>>? predicate = null,
        Func<IQueryable<HospitalAddress>, IOrderedQueryable<HospitalAddress>>? orderBy = null,
        Func<IQueryable<HospitalAddress>, IIncludableQueryable<HospitalAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<HospitalAddress> AddAsync(HospitalAddress hospitalAddress);
    Task<HospitalAddress> UpdateAsync(HospitalAddress hospitalAddress);
    Task<HospitalAddress> DeleteAsync(HospitalAddress hospitalAddress, bool permanent = false);
}
