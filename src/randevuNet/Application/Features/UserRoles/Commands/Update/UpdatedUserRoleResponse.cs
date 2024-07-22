using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserRoles.Commands.Update;

public class UpdatedUserRoleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}