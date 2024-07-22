using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DepartmentRepository : EfRepositoryBase<Department, int, BaseDbContext>, IDepartmentRepository
{
    public DepartmentRepository(BaseDbContext context) : base(context)
    {
    }
}