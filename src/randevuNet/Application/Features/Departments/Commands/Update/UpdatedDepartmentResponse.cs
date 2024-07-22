using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Commands.Update;

public class UpdatedDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}