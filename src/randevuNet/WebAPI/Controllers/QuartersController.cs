using Application.Features.Quarters.Commands.Create;
using Application.Features.Quarters.Commands.Delete;
using Application.Features.Quarters.Commands.Update;
using Application.Features.Quarters.Queries.GetById;
using Application.Features.Quarters.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuartersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedQuarterResponse>> Add([FromBody] CreateQuarterCommand command)
    {
        CreatedQuarterResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedQuarterResponse>> Update([FromBody] UpdateQuarterCommand command)
    {
        UpdatedQuarterResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedQuarterResponse>> Delete([FromRoute] int id)
    {
        DeleteQuarterCommand command = new() { Id = id };

        DeletedQuarterResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdQuarterResponse>> GetById([FromRoute] int id)
    {
        GetByIdQuarterQuery query = new() { Id = id };

        GetByIdQuarterResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListQuarterQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListQuarterQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListQuarterListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}