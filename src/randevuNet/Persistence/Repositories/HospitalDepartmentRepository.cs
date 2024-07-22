using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class HospitalDepartmentRepository : EfRepositoryBase<Hospital_Department, int, BaseDbContext>, IHospitalDepartmentRepository
{
    public HospitalDepartmentRepository(BaseDbContext context) : base(context)
    {
    }
}