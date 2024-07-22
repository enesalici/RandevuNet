using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class DoctorScheduleSlot : Entity<int>
{
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public Guid DoctorID { get; set; }

    public virtual Doctor Doctor { get; set; }
    //public virtual ICollection<Appointment> Appointments { get; set; }
    public virtual Appointment Appointment { get; set; }
}
