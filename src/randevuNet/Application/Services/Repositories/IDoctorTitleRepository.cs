using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDoctorTitleRepository : IAsyncRepository<DoctorTitle, int>, IRepository<DoctorTitle, int>
{
}