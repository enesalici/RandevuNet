using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserRoles.Commands.Create;

public class CreatedUserRoleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}