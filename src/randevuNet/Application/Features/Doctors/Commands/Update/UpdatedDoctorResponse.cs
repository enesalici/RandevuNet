using NArchitecture.Core.Application.Responses;

namespace Application.Features.Doctors.Commands.Update;

public class UpdatedDoctorResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? Education { get; set; }
    public string? ProfilePhoto { get; set; }
    public int DoctorTitleID { get; set; }
    public int HospitalDepartmentID { get; set; }
    public int UserRoleID { get; set; }

}