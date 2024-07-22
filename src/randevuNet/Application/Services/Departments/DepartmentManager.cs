using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Departments;

public class DepartmentManager : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly DepartmentBusinessRules _departmentBusinessRules;

    public DepartmentManager(IDepartmentRepository departmentRepository, DepartmentBusinessRules departmentBusinessRules)
    {
        _departmentRepository = departmentRepository;
        _departmentBusinessRules = departmentBusinessRules;
    }

    public async Task<Department?> GetAsync(
        Expression<Func<Department, bool>> predicate,
        Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Department? department = await _departmentRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return department;
    }

    public async Task<IPaginate<Department>?> GetListAsync(
        Expression<Func<Department, bool>>? predicate = null,
        Func<IQueryable<Department>, IOrderedQueryable<Department>>? orderBy = null,
        Func<IQueryable<Department>, IIncludableQueryable<Department, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Department> departmentList = await _departmentRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return departmentList;
    }

    public async Task<Department> AddAsync(Department department)
    {
        Department addedDepartment = await _departmentRepository.AddAsync(department);

        return addedDepartment;
    }

    public async Task<Department> UpdateAsync(Department department)
    {
        Department updatedDepartment = await _departmentRepository.UpdateAsync(department);

        return updatedDepartment;
    }

    public async Task<Department> DeleteAsync(Department department, bool permanent = false)
    {
        Department deletedDepartment = await _departmentRepository.DeleteAsync(department);

        return deletedDepartment;
    }
}
