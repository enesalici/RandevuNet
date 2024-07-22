using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Commands.Create;

public class CreatedDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}