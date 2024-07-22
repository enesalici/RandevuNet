using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IDoctorScheduleSlotRepository : IAsyncRepository<DoctorScheduleSlot, int>, IRepository<DoctorScheduleSlot, int>
{
    Task<List<DoctorScheduleSlot>> GetDoctorSchedulesByDoctorIdAsync(Guid doctorId);
}