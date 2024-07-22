using Application.Features.Quarters.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Quarters;

public class QuarterManager : IQuarterService
{
    private readonly IQuarterRepository _quarterRepository;
    private readonly QuarterBusinessRules _quarterBusinessRules;

    public QuarterManager(IQuarterRepository quarterRepository, QuarterBusinessRules quarterBusinessRules)
    {
        _quarterRepository = quarterRepository;
        _quarterBusinessRules = quarterBusinessRules;
    }

    public async Task<Quarter?> GetAsync(
        Expression<Func<Quarter, bool>> predicate,
        Func<IQueryable<Quarter>, IIncludableQueryable<Quarter, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Quarter? quarter = await _quarterRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return quarter;
    }

    public async Task<IPaginate<Quarter>?> GetListAsync(
        Expression<Func<Quarter, bool>>? predicate = null,
        Func<IQueryable<Quarter>, IOrderedQueryable<Quarter>>? orderBy = null,
        Func<IQueryable<Quarter>, IIncludableQueryable<Quarter, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Quarter> quarterList = await _quarterRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return quarterList;
    }

    public async Task<Quarter> AddAsync(Quarter quarter)
    {
        Quarter addedQuarter = await _quarterRepository.AddAsync(quarter);

        return addedQuarter;
    }

    public async Task<Quarter> UpdateAsync(Quarter quarter)
    {
        Quarter updatedQuarter = await _quarterRepository.UpdateAsync(quarter);

        return updatedQuarter;
    }

    public async Task<Quarter> DeleteAsync(Quarter quarter, bool permanent = false)
    {
        Quarter deletedQuarter = await _quarterRepository.DeleteAsync(quarter);

        return deletedQuarter;
    }
}
