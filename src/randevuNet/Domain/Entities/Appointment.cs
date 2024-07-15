using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Appointment : Entity<Guid>
{
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Created;

    public Guid PatientId { get; set; }
    public int DoctorScheduleSlotId { get; set; }

    public virtual Patient Patient { get; set; }
    public virtual DoctorScheduleSlot DoctorScheduleSlot { get; set; }
    public virtual ICollection<AppointmentReport> AppointmentReports { get; set; }
}
