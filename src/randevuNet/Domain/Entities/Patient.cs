namespace Domain.Entities;
public class Patient : User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; }
}
