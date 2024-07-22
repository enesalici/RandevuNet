using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Doctors.Queries.GetList;

public class GetListDoctorListItemDto : IDto
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


    public string? DoctorTitleName { get; set; }
    public string? HospitalName { get; set; }
    public string? DepartmentName { get; set; }

}