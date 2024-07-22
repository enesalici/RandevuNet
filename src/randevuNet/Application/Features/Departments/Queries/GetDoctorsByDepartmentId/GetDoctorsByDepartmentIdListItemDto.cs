using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Departments.Queries.GetDoctorsByDepartmentId;

public class GetDoctorsByDepartmentIdListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? Education { get; set; }
    public string? ProfilePhoto { get; set; }

    public int DoctorTitleID { get; set; }
    public string DoctorTitleName { get; set; }
    public int DoctorTitleLevelIndex { get; set; }
}
