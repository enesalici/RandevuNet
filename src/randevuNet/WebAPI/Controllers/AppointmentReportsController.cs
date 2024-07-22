using Application.Features.AppointmentReports.Commands.Create;
using Application.Features.AppointmentReports.Commands.Delete;
using Application.Features.AppointmentReports.Commands.Update;
using Application.Features.AppointmentReports.Queries.GetById;
using Application.Features.AppointmentReports.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentReportsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedAppointmentReportResponse>> Add([FromBody] CreateAppointmentReportCommand command)
    {
        CreatedAppointmentReportResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedAppointmentReportResponse>> Update([FromBody] UpdateAppointmentReportCommand command)
    {
        UpdatedAppointmentReportResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedAppointmentReportResponse>> Delete([FromRoute] int id)
    {
        DeleteAppointmentReportCommand command = new() { Id = id };

        DeletedAppointmentReportResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdAppointmentReportResponse>> GetById([FromRoute] int id)
    {
        GetByIdAppointmentReportQuery query = new() { Id = id };

        GetByIdAppointmentReportResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListAppointmentReportQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAppointmentReportQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListAppointmentReportListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}