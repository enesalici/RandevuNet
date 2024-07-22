using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalDepartments.Queries.GetById;

public class GetByIdHospitalDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public int HospitalID { get; set; }
    public int DepartmentID { get; set; }
    public string HospitalName { get; set; }
    public string DepartmentName { get; set; }
}