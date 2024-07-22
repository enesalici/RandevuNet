using Application.Features.HospitalDepartments.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.HospitalDepartments;

public class HospitalDepartmentManager : IHospitalDepartmentService
{
    private readonly IHospitalDepartmentRepository _hospitalDepartmentRepository;
    private readonly HospitalDepartmentBusinessRules _hospitalDepartmentBusinessRules;

    public HospitalDepartmentManager(IHospitalDepartmentRepository hospitalDepartmentRepository, HospitalDepartmentBusinessRules hospitalDepartmentBusinessRules)
    {
        _hospitalDepartmentRepository = hospitalDepartmentRepository;
        _hospitalDepartmentBusinessRules = hospitalDepartmentBusinessRules;
    }

    public async Task<Hospital_Department?> GetAsync(
        Expression<Func<Hospital_Department, bool>> predicate,
        Func<IQueryable<Hospital_Department>, IIncludableQueryable<Hospital_Department, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Hospital_Department? hospitalDepartment = await _hospitalDepartmentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return hospitalDepartment;
    }

    public async Task<IPaginate<Hospital_Department>?> GetListAsync(
        Expression<Func<Hospital_Department, bool>>? predicate = null,
        Func<IQueryable<Hospital_Department>, IOrderedQueryable<Hospital_Department>>? orderBy = null,
        Func<IQueryable<Hospital_Department>, IIncludableQueryable<Hospital_Department, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Hospital_Department> hospitalDepartmentList = await _hospitalDepartmentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return hospitalDepartmentList;
    }

    public async Task<Hospital_Department> AddAsync(Hospital_Department hospitalDepartment)
    {
        Hospital_Department addedHospitalDepartment = await _hospitalDepartmentRepository.AddAsync(hospitalDepartment);

        return addedHospitalDepartment;
    }

    public async Task<Hospital_Department> UpdateAsync(Hospital_Department hospitalDepartment)
    {
        Hospital_Department updatedHospitalDepartment = await _hospitalDepartmentRepository.UpdateAsync(hospitalDepartment);

        return updatedHospitalDepartment;
    }

    public async Task<Hospital_Department> DeleteAsync(Hospital_Department hospitalDepartment, bool permanent = false)
    {
        Hospital_Department deletedHospitalDepartment = await _hospitalDepartmentRepository.DeleteAsync(hospitalDepartment);

        return deletedHospitalDepartment;
    }
}
