using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class AppointmentReport : Entity<int>
{
    public string Title { get; set; }
    public string Detail { get; set; }

    public Guid AppointmentID { get; set; }

    public virtual Appointment Appointment { get; set; }
}
