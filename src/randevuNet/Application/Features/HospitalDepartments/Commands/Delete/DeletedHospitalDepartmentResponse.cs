using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalDepartments.Commands.Delete;

public class DeletedHospitalDepartmentResponse : IResponse
{
    public int Id { get; set; }
}