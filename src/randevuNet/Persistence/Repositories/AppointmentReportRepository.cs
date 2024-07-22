using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AppointmentReportRepository : EfRepositoryBase<AppointmentReport, int, BaseDbContext>, IAppointmentReportRepository
{
    public AppointmentReportRepository(BaseDbContext context) : base(context)
    {
    }
}