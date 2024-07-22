using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class QuarterRepository : EfRepositoryBase<Quarter, int, BaseDbContext>, IQuarterRepository
{
    public QuarterRepository(BaseDbContext context) : base(context)
    {
    }
}