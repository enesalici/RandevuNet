using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IQuarterRepository : IAsyncRepository<Quarter, int>, IRepository<Quarter, int>
{
}