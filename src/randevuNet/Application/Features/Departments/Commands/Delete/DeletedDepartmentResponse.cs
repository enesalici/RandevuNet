using NArchitecture.Core.Application.Responses;

namespace Application.Features.Departments.Commands.Delete;

public class DeletedDepartmentResponse : IResponse
{
    public int Id { get; set; }
}