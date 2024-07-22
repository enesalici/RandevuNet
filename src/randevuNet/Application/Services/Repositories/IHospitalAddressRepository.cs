using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IHospitalAddressRepository : IAsyncRepository<HospitalAddress, int>, IRepository<HospitalAddress, int>
{
}