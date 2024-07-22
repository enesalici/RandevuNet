using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Districts.Queries.GetQuartersByDistrictId;
using Application.Features.Cities.Queries.GetDistrictsByCityId;
using MediatR;
using Domain.Entities;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistrictsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDistrictResponse>> Add([FromBody] CreateDistrictCommand command)
    {
        CreatedDistrictResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDistrictResponse>> Update([FromBody] UpdateDistrictCommand command)
    {
        UpdatedDistrictResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDistrictResponse>> Delete([FromRoute] int id)
    {
        DeleteDistrictCommand command = new() { Id = id };

        DeletedDistrictResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDistrictResponse>> GetById([FromRoute] int id)
    {
        GetByIdDistrictQuery query = new() { Id = id };

        GetByIdDistrictResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListDistrictQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDistrictQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDistrictListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet("{districtId}/quarters")]
    public async Task<IActionResult> GetQuartersByDistrictId([FromRoute] int districtId, [FromQuery] PageRequest pageRequest)
    {
        var query = new GetQuartersByDistrictIdQuery() { DistrictId = districtId, PageRequest = pageRequest };
        GetListResponse<GetQuartersByDistrictIdListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}
