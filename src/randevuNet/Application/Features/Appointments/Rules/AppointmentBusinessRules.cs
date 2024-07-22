using Application.Features.Appointments.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Appointments.Rules;

public class AppointmentBusinessRules : BaseBusinessRules
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly ILocalizationService _localizationService;

    public AppointmentBusinessRules(IAppointmentRepository appointmentRepository, ILocalizationService localizationService)
    {
        _appointmentRepository = appointmentRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AppointmentsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AppointmentShouldExistWhenSelected(Appointment? appointment)
    {
        if (appointment == null)
            await throwBusinessException(AppointmentsBusinessMessages.AppointmentNotExists);
    }

    public async Task AppointmentIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Appointment? appointment = await _appointmentRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AppointmentShouldExistWhenSelected(appointment);
    }
}