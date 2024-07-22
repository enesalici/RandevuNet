using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IHospitalDepartmentRepository : IAsyncRepository<Hospital_Department, int>, IRepository<Hospital_Department, int>
{
}