using Application.Features.AppointmentReports.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AppointmentReports.Rules;

public class AppointmentReportBusinessRules : BaseBusinessRules
{
    private readonly IAppointmentReportRepository _appointmentReportRepository;
    private readonly ILocalizationService _localizationService;

    public AppointmentReportBusinessRules(IAppointmentReportRepository appointmentReportRepository, ILocalizationService localizationService)
    {
        _appointmentReportRepository = appointmentReportRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AppointmentReportsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AppointmentReportShouldExistWhenSelected(AppointmentReport? appointmentReport)
    {
        if (appointmentReport == null)
            await throwBusinessException(AppointmentReportsBusinessMessages.AppointmentReportNotExists);
    }

    public async Task AppointmentReportIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        AppointmentReport? appointmentReport = await _appointmentReportRepository.GetAsync(
            predicate: ar => ar.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AppointmentReportShouldExistWhenSelected(appointmentReport);
    }
}