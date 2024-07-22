using Application.Features.DoctorScheduleSlots.Commands.Create;
using Application.Features.DoctorScheduleSlots.Commands.Delete;
using Application.Features.DoctorScheduleSlots.Commands.Update;
using Application.Features.DoctorScheduleSlots.Queries.GetById;
using Application.Features.DoctorScheduleSlots.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorScheduleSlotsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDoctorScheduleSlotResponse>> Add([FromBody] CreateDoctorScheduleSlotCommand command)
    {
        CreatedDoctorScheduleSlotResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDoctorScheduleSlotResponse>> Update([FromBody] UpdateDoctorScheduleSlotCommand command)
    {
        UpdatedDoctorScheduleSlotResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDoctorScheduleSlotResponse>> Delete([FromRoute] int id)
    {
        DeleteDoctorScheduleSlotCommand command = new() { Id = id };

        DeletedDoctorScheduleSlotResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDoctorScheduleSlotResponse>> GetById([FromRoute] int id)
    {
        GetByIdDoctorScheduleSlotQuery query = new() { Id = id };

        GetByIdDoctorScheduleSlotResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListDoctorScheduleSlotQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDoctorScheduleSlotQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDoctorScheduleSlotListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}