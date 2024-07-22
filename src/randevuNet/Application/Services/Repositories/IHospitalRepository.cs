using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IHospitalRepository : IAsyncRepository<Hospital, int>, IRepository<Hospital, int>
{
}