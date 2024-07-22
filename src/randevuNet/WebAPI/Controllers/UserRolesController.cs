using Application.Features.UserRoles.Commands.Create;
using Application.Features.UserRoles.Commands.Delete;
using Application.Features.UserRoles.Commands.Update;
using Application.Features.UserRoles.Queries.GetById;
using Application.Features.UserRoles.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRolesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserRoleResponse>> Add([FromBody] CreateUserRoleCommand command)
    {
        CreatedUserRoleResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserRoleResponse>> Update([FromBody] UpdateUserRoleCommand command)
    {
        UpdatedUserRoleResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserRoleResponse>> Delete([FromRoute] int id)
    {
        DeleteUserRoleCommand command = new() { Id = id };

        DeletedUserRoleResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserRoleResponse>> GetById([FromRoute] int id)
    {
        GetByIdUserRoleQuery query = new() { Id = id };

        GetByIdUserRoleResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListUserRoleQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserRoleQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserRoleListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}