using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Hospitals.Queries.GetDepartmentsByHospitalId;

public class GetDepartmentsByHospitalIdListItemDto : IDto
{
    public int Id { get; set; }
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
}

