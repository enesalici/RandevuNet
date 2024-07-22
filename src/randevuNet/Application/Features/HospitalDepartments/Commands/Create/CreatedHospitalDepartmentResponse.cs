using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalDepartments.Commands.Create;

public class CreatedHospitalDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public int HospitalID { get; set; }
    public int DepartmentID { get; set; }
}