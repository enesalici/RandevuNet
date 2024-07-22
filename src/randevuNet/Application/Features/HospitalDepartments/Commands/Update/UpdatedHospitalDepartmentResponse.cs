using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalDepartments.Commands.Update;

public class UpdatedHospitalDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public int HospitalID { get; set; }
    public int DepartmentID { get; set; }
}