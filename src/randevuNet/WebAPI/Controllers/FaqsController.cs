using Application.Features.Faqs.Commands.Create;
using Application.Features.Faqs.Commands.Delete;
using Application.Features.Faqs.Commands.Update;
using Application.Features.Faqs.Queries.GetById;
using Application.Features.Faqs.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FaqsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFaqResponse>> Add([FromBody] CreateFaqCommand command)
    {
        CreatedFaqResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFaqResponse>> Update([FromBody] UpdateFaqCommand command)
    {
        UpdatedFaqResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFaqResponse>> Delete([FromRoute] int id)
    {
        DeleteFaqCommand command = new() { Id = id };

        DeletedFaqResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFaqResponse>> GetById([FromRoute] int id)
    {
        GetByIdFaqQuery query = new() { Id = id };

        GetByIdFaqResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListFaqQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFaqQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFaqListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}