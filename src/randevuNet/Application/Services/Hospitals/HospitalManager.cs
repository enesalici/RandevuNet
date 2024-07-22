using Application.Features.Hospitals.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Hospitals;

public class HospitalManager : IHospitalService
{
    private readonly IHospitalRepository _hospitalRepository;
    private readonly HospitalBusinessRules _hospitalBusinessRules;

    public HospitalManager(IHospitalRepository hospitalRepository, HospitalBusinessRules hospitalBusinessRules)
    {
        _hospitalRepository = hospitalRepository;
        _hospitalBusinessRules = hospitalBusinessRules;
    }

    public async Task<Hospital?> GetAsync(
        Expression<Func<Hospital, bool>> predicate,
        Func<IQueryable<Hospital>, IIncludableQueryable<Hospital, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Hospital? hospital = await _hospitalRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return hospital;
    }

    public async Task<IPaginate<Hospital>?> GetListAsync(
        Expression<Func<Hospital, bool>>? predicate = null,
        Func<IQueryable<Hospital>, IOrderedQueryable<Hospital>>? orderBy = null,
        Func<IQueryable<Hospital>, IIncludableQueryable<Hospital, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Hospital> hospitalList = await _hospitalRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return hospitalList;
    }

    public async Task<Hospital> AddAsync(Hospital hospital)
    {
        Hospital addedHospital = await _hospitalRepository.AddAsync(hospital);

        return addedHospital;
    }

    public async Task<Hospital> UpdateAsync(Hospital hospital)
    {
        Hospital updatedHospital = await _hospitalRepository.UpdateAsync(hospital);

        return updatedHospital;
    }

    public async Task<Hospital> DeleteAsync(Hospital hospital, bool permanent = false)
    {
        Hospital deletedHospital = await _hospitalRepository.DeleteAsync(hospital);

        return deletedHospital;
    }
}
