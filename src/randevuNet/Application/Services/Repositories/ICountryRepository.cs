using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICountryRepository : IAsyncRepository<Country, int>, IRepository<Country, int>
{
}