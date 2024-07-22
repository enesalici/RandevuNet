using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using System.Linq.Dynamic.Core;

namespace Persistence.Repositories;

public class DoctorScheduleSlotRepository : EfRepositoryBase<DoctorScheduleSlot, int, BaseDbContext>, IDoctorScheduleSlotRepository
{
    private readonly BaseDbContext _context;
    public DoctorScheduleSlotRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<DoctorScheduleSlot>> GetDoctorSchedulesByDoctorIdAsync(Guid doctorId)
    {
        return await _context.DoctorScheduleSlots
                     .Include(ds => ds.Doctor)
                     .ThenInclude(d=>d.DoctorTitle)
                     .Where(ds => ds.DoctorID == doctorId && ds.Appointment.DoctorScheduleSlotId != ds.Id)
                     .OrderBy(ds => ds. Date)
                     .ThenBy(ds => ds.StartTime)
                     .ToListAsync();
    }
}