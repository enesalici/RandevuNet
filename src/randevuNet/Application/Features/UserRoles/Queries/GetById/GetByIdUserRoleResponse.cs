using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserRoles.Queries.GetById;

public class GetByIdUserRoleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}