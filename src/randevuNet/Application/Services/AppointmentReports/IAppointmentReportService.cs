using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.AppointmentReports;

public interface IAppointmentReportService
{
    Task<AppointmentReport?> GetAsync(
        Expression<Func<AppointmentReport, bool>> predicate,
        Func<IQueryable<AppointmentReport>, IIncludableQueryable<AppointmentReport, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<AppointmentReport>?> GetListAsync(
        Expression<Func<AppointmentReport, bool>>? predicate = null,
        Func<IQueryable<AppointmentReport>, IOrderedQueryable<AppointmentReport>>? orderBy = null,
        Func<IQueryable<AppointmentReport>, IIncludableQueryable<AppointmentReport, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<AppointmentReport> AddAsync(AppointmentReport appointmentReport);
    Task<AppointmentReport> UpdateAsync(AppointmentReport appointmentReport);
    Task<AppointmentReport> DeleteAsync(AppointmentReport appointmentReport, bool permanent = false);
}
