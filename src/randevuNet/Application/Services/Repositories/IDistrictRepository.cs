using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDistrictRepository : IAsyncRepository<District, int>, IRepository<District, int>
{
}