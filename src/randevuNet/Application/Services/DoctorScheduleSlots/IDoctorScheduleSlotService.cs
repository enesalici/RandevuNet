using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DoctorScheduleSlots;

public interface IDoctorScheduleSlotService
{
    Task<DoctorScheduleSlot?> GetAsync(
        Expression<Func<DoctorScheduleSlot, bool>> predicate,
        Func<IQueryable<DoctorScheduleSlot>, IIncludableQueryable<DoctorScheduleSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<DoctorScheduleSlot>?> GetListAsync(
        Expression<Func<DoctorScheduleSlot, bool>>? predicate = null,
        Func<IQueryable<DoctorScheduleSlot>, IOrderedQueryable<DoctorScheduleSlot>>? orderBy = null,
        Func<IQueryable<DoctorScheduleSlot>, IIncludableQueryable<DoctorScheduleSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<DoctorScheduleSlot> AddAsync(DoctorScheduleSlot doctorScheduleSlot);
    Task<DoctorScheduleSlot> UpdateAsync(DoctorScheduleSlot doctorScheduleSlot);
    Task<DoctorScheduleSlot> DeleteAsync(DoctorScheduleSlot doctorScheduleSlot, bool permanent = false);
}
