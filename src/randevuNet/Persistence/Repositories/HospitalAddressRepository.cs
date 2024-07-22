using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class HospitalAddressRepository : EfRepositoryBase<HospitalAddress, int, BaseDbContext>, IHospitalAddressRepository
{
    public HospitalAddressRepository(BaseDbContext context) : base(context)
    {
    }
}