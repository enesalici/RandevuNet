using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IUserRoleRepository : IAsyncRepository<UserRole, int>, IRepository<UserRole, int>
{
}