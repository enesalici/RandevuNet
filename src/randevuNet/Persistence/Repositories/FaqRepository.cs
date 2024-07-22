using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FaqRepository : EfRepositoryBase<Faq, int, BaseDbContext>, IFaqRepository
{
    public FaqRepository(BaseDbContext context) : base(context)
    {
    }
}