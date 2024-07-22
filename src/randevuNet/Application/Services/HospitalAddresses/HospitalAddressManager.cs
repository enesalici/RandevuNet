using Application.Features.HospitalAddresses.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HospitalAddresses;

public class HospitalAddressManager : IHospitalAddressService
{
    private readonly IHospitalAddressRepository _hospitalAddressRepository;
    private readonly HospitalAddressBusinessRules _hospitalAddressBusinessRules;

    public HospitalAddressManager(IHospitalAddressRepository hospitalAddressRepository, HospitalAddressBusinessRules hospitalAddressBusinessRules)
    {
        _hospitalAddressRepository = hospitalAddressRepository;
        _hospitalAddressBusinessRules = hospitalAddressBusinessRules;
    }

    public async Task<HospitalAddress?> GetAsync(
        Expression<Func<HospitalAddress, bool>> predicate,
        Func<IQueryable<HospitalAddress>, IIncludableQueryable<HospitalAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        HospitalAddress? hospitalAddress = await _hospitalAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return hospitalAddress;
    }

    public async Task<IPaginate<HospitalAddress>?> GetListAsync(
        Expression<Func<HospitalAddress, bool>>? predicate = null,
        Func<IQueryable<HospitalAddress>, IOrderedQueryable<HospitalAddress>>? orderBy = null,
        Func<IQueryable<HospitalAddress>, IIncludableQueryable<HospitalAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<HospitalAddress> hospitalAddressList = await _hospitalAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return hospitalAddressList;
    }

    public async Task<HospitalAddress> AddAsync(HospitalAddress hospitalAddress)
    {
        HospitalAddress addedHospitalAddress = await _hospitalAddressRepository.AddAsync(hospitalAddress);

        return addedHospitalAddress;
    }

    public async Task<HospitalAddress> UpdateAsync(HospitalAddress hospitalAddress)
    {
        HospitalAddress updatedHospitalAddress = await _hospitalAddressRepository.UpdateAsync(hospitalAddress);

        return updatedHospitalAddress;
    }

    public async Task<HospitalAddress> DeleteAsync(HospitalAddress hospitalAddress, bool permanent = false)
    {
        HospitalAddress deletedHospitalAddress = await _hospitalAddressRepository.DeleteAsync(hospitalAddress);

        return deletedHospitalAddress;
    }
}
