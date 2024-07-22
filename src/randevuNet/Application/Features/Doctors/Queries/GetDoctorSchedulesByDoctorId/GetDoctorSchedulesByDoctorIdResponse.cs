namespace Application.Features.Doctors.Queries.GetDoctorSchedulesByDoctorId;

public class GetDoctorSchedulesByDoctorIdResponse  
{
    public int ID { get; set; }
    public Guid DoctorID { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DoctorTitleID { get; set; }
    public string DoctorTitleName { get; set; }
    public int UserRoleID { get; set; }

}
