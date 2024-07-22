using Application.Features.HospitalDepartments.Commands.Create;
using Application.Features.HospitalDepartments.Commands.Delete;
using Application.Features.HospitalDepartments.Commands.Update;
using Application.Features.HospitalDepartments.Queries.GetById;
using Application.Features.HospitalDepartments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalDepartmentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedHospitalDepartmentResponse>> Add([FromBody] CreateHospitalDepartmentCommand command)
    {
        CreatedHospitalDepartmentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedHospitalDepartmentResponse>> Update([FromBody] UpdateHospitalDepartmentCommand command)
    {
        UpdatedHospitalDepartmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedHospitalDepartmentResponse>> Delete([FromRoute] int id)
    {
        DeleteHospitalDepartmentCommand command = new() { Id = id };

        DeletedHospitalDepartmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdHospitalDepartmentResponse>> GetById([FromRoute] int id)
    {
        GetByIdHospitalDepartmentQuery query = new() { Id = id };

        GetByIdHospitalDepartmentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListHospitalDepartmentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListHospitalDepartmentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListHospitalDepartmentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}
