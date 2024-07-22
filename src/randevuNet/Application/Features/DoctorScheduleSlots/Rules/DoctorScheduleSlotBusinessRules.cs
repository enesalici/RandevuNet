using Application.Features.DoctorScheduleSlots.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.DoctorScheduleSlots.Rules;

public class DoctorScheduleSlotBusinessRules : BaseBusinessRules
{
    private readonly IDoctorScheduleSlotRepository _doctorScheduleSlotRepository;
    private readonly ILocalizationService _localizationService;

    public DoctorScheduleSlotBusinessRules(IDoctorScheduleSlotRepository doctorScheduleSlotRepository, ILocalizationService localizationService)
    {
        _doctorScheduleSlotRepository = doctorScheduleSlotRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DoctorScheduleSlotsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DoctorScheduleSlotShouldExistWhenSelected(DoctorScheduleSlot? doctorScheduleSlot)
    {
        if (doctorScheduleSlot == null)
            await throwBusinessException(DoctorScheduleSlotsBusinessMessages.DoctorScheduleSlotNotExists);
    }

    public async Task DoctorScheduleSlotIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        DoctorScheduleSlot? doctorScheduleSlot = await _doctorScheduleSlotRepository.GetAsync(
            predicate: dss => dss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DoctorScheduleSlotShouldExistWhenSelected(doctorScheduleSlot);
    }
}