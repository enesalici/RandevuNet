using Application.Features.DoctorTitles.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DoctorTitles;

public class DoctorTitleManager : IDoctorTitleService
{
    private readonly IDoctorTitleRepository _doctorTitleRepository;
    private readonly DoctorTitleBusinessRules _doctorTitleBusinessRules;

    public DoctorTitleManager(IDoctorTitleRepository doctorTitleRepository, DoctorTitleBusinessRules doctorTitleBusinessRules)
    {
        _doctorTitleRepository = doctorTitleRepository;
        _doctorTitleBusinessRules = doctorTitleBusinessRules;
    }

    public async Task<DoctorTitle?> GetAsync(
        Expression<Func<DoctorTitle, bool>> predicate,
        Func<IQueryable<DoctorTitle>, IIncludableQueryable<DoctorTitle, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DoctorTitle? doctorTitle = await _doctorTitleRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return doctorTitle;
    }

    public async Task<IPaginate<DoctorTitle>?> GetListAsync(
        Expression<Func<DoctorTitle, bool>>? predicate = null,
        Func<IQueryable<DoctorTitle>, IOrderedQueryable<DoctorTitle>>? orderBy = null,
        Func<IQueryable<DoctorTitle>, IIncludableQueryable<DoctorTitle, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DoctorTitle> doctorTitleList = await _doctorTitleRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return doctorTitleList;
    }

    public async Task<DoctorTitle> AddAsync(DoctorTitle doctorTitle)
    {
        DoctorTitle addedDoctorTitle = await _doctorTitleRepository.AddAsync(doctorTitle);

        return addedDoctorTitle;
    }

    public async Task<DoctorTitle> UpdateAsync(DoctorTitle doctorTitle)
    {
        DoctorTitle updatedDoctorTitle = await _doctorTitleRepository.UpdateAsync(doctorTitle);

        return updatedDoctorTitle;
    }

    public async Task<DoctorTitle> DeleteAsync(DoctorTitle doctorTitle, bool permanent = false)
    {
        DoctorTitle deletedDoctorTitle = await _doctorTitleRepository.DeleteAsync(doctorTitle);

        return deletedDoctorTitle;
    }
}
