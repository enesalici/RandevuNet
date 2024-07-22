using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRoleRepository : EfRepositoryBase<UserRole, int, BaseDbContext>, IUserRoleRepository
{
    public UserRoleRepository(BaseDbContext context) : base(context)
    {
    }
}