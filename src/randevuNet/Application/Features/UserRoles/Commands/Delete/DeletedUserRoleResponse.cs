using NArchitecture.Core.Application.Responses;

namespace Application.Features.UserRoles.Commands.Delete;

public class DeletedUserRoleResponse : IResponse
{
    public int Id { get; set; }
}