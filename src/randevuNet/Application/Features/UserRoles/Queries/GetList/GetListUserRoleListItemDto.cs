using NArchitecture.Core.Application.Dtos;

namespace Application.Features.UserRoles.Queries.GetList;

public class GetListUserRoleListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}