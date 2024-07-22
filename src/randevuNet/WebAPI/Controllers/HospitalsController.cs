using Application.Features.Hospitals.Commands.Create;
using Application.Features.Hospitals.Commands.Delete;
using Application.Features.Hospitals.Commands.Update;
using Application.Features.Hospitals.Queries.GetById;
using Application.Features.Hospitals.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Hospitals.Queries.GetDepartmentsByHospitalId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedHospitalResponse>> Add([FromBody] CreateHospitalCommand command)
    {
        CreatedHospitalResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedHospitalResponse>> Update([FromBody] UpdateHospitalCommand command)
    {
        UpdatedHospitalResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedHospitalResponse>> Delete([FromRoute] int id)
    {
        DeleteHospitalCommand command = new() { Id = id };

        DeletedHospitalResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdHospitalResponse>> GetById([FromRoute] int id)
    {
        GetByIdHospitalQuery query = new() { Id = id };

        GetByIdHospitalResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListHospitalQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListHospitalQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListHospitalListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }


    [HttpGet("{hospitalID}/departments")]
    public async Task<IActionResult> GetDepartmentsByHospitalId([FromRoute] int hospitalID, [FromQuery] PageRequest pageRequest)
    {
        GetDepartmentsByHospitalIdQuery query = new() { HospitalID = hospitalID, PageRequest = pageRequest };

        GetListResponse<GetDepartmentsByHospitalIdListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}
