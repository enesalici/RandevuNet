using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Queries.GetById;

public class GetByIdDepartmentResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}