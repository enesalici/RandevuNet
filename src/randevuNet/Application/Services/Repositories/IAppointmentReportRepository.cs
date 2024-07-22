using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IAppointmentReportRepository : IAsyncRepository<AppointmentReport, int>, IRepository<AppointmentReport, int>
{
}