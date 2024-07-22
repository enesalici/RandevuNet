using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
//public class Patient : Entity<Guid>
public class Patient : User
{
    public string? ProfilePhoto { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; }
}
