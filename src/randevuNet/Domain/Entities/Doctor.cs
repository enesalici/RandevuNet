namespace Domain.Entities;
public class Doctor : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? Education { get; set; }

    public int DepartmentID { get; set; }

    public virtual Department Department { get; set; }
    public virtual ICollection<DoctorScheduleSlot> DoctorScheduleSlots { get; set; }
}
