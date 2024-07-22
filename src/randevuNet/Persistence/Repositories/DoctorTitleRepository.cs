using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DoctorTitleRepository : EfRepositoryBase<DoctorTitle, int, BaseDbContext>, IDoctorTitleRepository
{
    public DoctorTitleRepository(BaseDbContext context) : base(context)
    {
    }
}