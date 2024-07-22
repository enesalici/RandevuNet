using Application.Features.DoctorTitles.Commands.Create;
using Application.Features.DoctorTitles.Commands.Delete;
using Application.Features.DoctorTitles.Commands.Update;
using Application.Features.DoctorTitles.Queries.GetById;
using Application.Features.DoctorTitles.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorTitlesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDoctorTitleResponse>> Add([FromBody] CreateDoctorTitleCommand command)
    {
        CreatedDoctorTitleResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDoctorTitleResponse>> Update([FromBody] UpdateDoctorTitleCommand command)
    {
        UpdatedDoctorTitleResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDoctorTitleResponse>> Delete([FromRoute] int id)
    {
        DeleteDoctorTitleCommand command = new() { Id = id };

        DeletedDoctorTitleResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDoctorTitleResponse>> GetById([FromRoute] int id)
    {
        GetByIdDoctorTitleQuery query = new() { Id = id };

        GetByIdDoctorTitleResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<GetListDoctorTitleQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDoctorTitleQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDoctorTitleListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}