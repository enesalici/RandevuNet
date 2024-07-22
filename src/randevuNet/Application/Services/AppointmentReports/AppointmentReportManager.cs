using Application.Features.AppointmentReports.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AppointmentReports;

public class AppointmentReportManager : IAppointmentReportService
{
    private readonly IAppointmentReportRepository _appointmentReportRepository;
    private readonly AppointmentReportBusinessRules _appointmentReportBusinessRules;

    public AppointmentReportManager(IAppointmentReportRepository appointmentReportRepository, AppointmentReportBusinessRules appointmentReportBusinessRules)
    {
        _appointmentReportRepository = appointmentReportRepository;
        _appointmentReportBusinessRules = appointmentReportBusinessRules;
    }

    public async Task<AppointmentReport?> GetAsync(
        Expression<Func<AppointmentReport, bool>> predicate,
        Func<IQueryable<AppointmentReport>, IIncludableQueryable<AppointmentReport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        AppointmentReport? appointmentReport = await _appointmentReportRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return appointmentReport;
    }

    public async Task<IPaginate<AppointmentReport>?> GetListAsync(
        Expression<Func<AppointmentReport, bool>>? predicate = null,
        Func<IQueryable<AppointmentReport>, IOrderedQueryable<AppointmentReport>>? orderBy = null,
        Func<IQueryable<AppointmentReport>, IIncludableQueryable<AppointmentReport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<AppointmentReport> appointmentReportList = await _appointmentReportRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return appointmentReportList;
    }

    public async Task<AppointmentReport> AddAsync(AppointmentReport appointmentReport)
    {
        AppointmentReport addedAppointmentReport = await _appointmentReportRepository.AddAsync(appointmentReport);

        return addedAppointmentReport;
    }

    public async Task<AppointmentReport> UpdateAsync(AppointmentReport appointmentReport)
    {
        AppointmentReport updatedAppointmentReport = await _appointmentReportRepository.UpdateAsync(appointmentReport);

        return updatedAppointmentReport;
    }

    public async Task<AppointmentReport> DeleteAsync(AppointmentReport appointmentReport, bool permanent = false)
    {
        AppointmentReport deletedAppointmentReport = await _appointmentReportRepository.DeleteAsync(appointmentReport);

        return deletedAppointmentReport;
    }
}
