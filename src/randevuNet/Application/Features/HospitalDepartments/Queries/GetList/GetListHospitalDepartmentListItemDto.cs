using NArchitecture.Core.Application.Dtos;

namespace Application.Features.HospitalDepartments.Queries.GetList;

public class GetListHospitalDepartmentListItemDto : IDto
{
    public int Id { get; set; }
    public int HospitalID { get; set; }
    public int DepartmentID { get; set; }
    public string HospitalName { get; set; }
    public string DepartmentName { get; set; }
}