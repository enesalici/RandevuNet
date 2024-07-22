using Application.Features.UserRoles.Commands.Create;
using Application.Features.UserRoles.Commands.Delete;
using Application.Features.UserRoles.Commands.Update;
using Application.Features.UserRoles.Queries.GetById;
using Application.Features.UserRoles.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserRoles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserRoleCommand, UserRole>();
        CreateMap<UserRole, CreatedUserRoleResponse>();

        CreateMap<UpdateUserRoleCommand, UserRole>();
        CreateMap<UserRole, UpdatedUserRoleResponse>();

        CreateMap<DeleteUserRoleCommand, UserRole>();
        CreateMap<UserRole, DeletedUserRoleResponse>();

        CreateMap<UserRole, GetByIdUserRoleResponse>();

        CreateMap<UserRole, GetListUserRoleListItemDto>();
        CreateMap<IPaginate<UserRole>, GetListResponse<GetListUserRoleListItemDto>>();
    }
}