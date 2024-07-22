using NArchitecture.Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
//public class Doctor : Entity<Guid>
public class Doctor : User
{

    public string? About { get; set; }
    public string? Education { get; set; }
    public string? ProfilePhoto { get; set; }

    public int DoctorTitleID { get; set; }
    public int Hospital_DepartmentID { get; set; }

    public virtual DoctorTitle DoctorTitle { get; set; }
    public virtual Hospital_Department Hospital_Department { get; set; }
    public virtual ICollection<DoctorScheduleSlot> DoctorScheduleSlots { get; set; }
}
