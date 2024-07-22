using Application.Features.DoctorScheduleSlots.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.DoctorScheduleSlots;

public class DoctorScheduleSlotManager : IDoctorScheduleSlotService
{
    private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
    private readonly DoctorScheduleSlotBusinessRules _doctorScheduleSlotBusinessRules;

    public DoctorScheduleSlotManager(IDoctorScheduleSlotRepository doctorScheduleSlotRepository, DoctorScheduleSlotBusinessRules doctorScheduleSlotBusinessRules)
    {
        _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
        _doctorScheduleSlotBusinessRules = doctorScheduleSlotBusinessRules;
    }

    public async Task<DoctorScheduleSlot?> GetAsync(
        Expression<Func<DoctorScheduleSlot, bool>> predicate,
        Func<IQueryable<DoctorScheduleSlot>, IIncludableQueryable<DoctorScheduleSlot, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        DoctorScheduleSlot? doctorScheduleSlot = await _doctorScheduleSlotRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return doctorScheduleSlot;
    }

    public async Task<IPaginate<DoctorScheduleSlot>?> GetListAsync(
        Expression<Func<DoctorScheduleSlot, bool>>? predicate = null,
        Func<IQueryable<DoctorScheduleSlot>, IOrderedQueryable<DoctorScheduleSlot>>? orderBy = null,
        Func<IQueryable<DoctorScheduleSlot>, IIncludableQueryable<DoctorScheduleSlot, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<DoctorScheduleSlot> doctorScheduleSlotList = await _doctorScheduleSlotRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return doctorScheduleSlotList;
    }

    public async Task<DoctorScheduleSlot> AddAsync(DoctorScheduleSlot doctorScheduleSlot)
    {
        DoctorScheduleSlot addedDoctorScheduleSlot = await _doctorScheduleSlotRepository.AddAsync(doctorScheduleSlot);

        return addedDoctorScheduleSlot;
    }

    public async Task<DoctorScheduleSlot> UpdateAsync(DoctorScheduleSlot doctorScheduleSlot)
    {
        DoctorScheduleSlot updatedDoctorScheduleSlot = await _doctorScheduleSlotRepository.UpdateAsync(doctorScheduleSlot);

        return updatedDoctorScheduleSlot;
    }

    public async Task<DoctorScheduleSlot> DeleteAsync(DoctorScheduleSlot doctorScheduleSlot, bool permanent = false)
    {
        DoctorScheduleSlot deletedDoctorScheduleSlot = await _doctorScheduleSlotRepository.DeleteAsync(doctorScheduleSlot);

        return deletedDoctorScheduleSlot;
    }
}
