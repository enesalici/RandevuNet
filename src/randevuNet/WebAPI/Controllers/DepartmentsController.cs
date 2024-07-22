using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Departments.Queries.GetDoctorsByDepartmentId;
using Application.Features.Departments.Queries.GetAvailableDoctors;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedDepartmentResponse>> Add([FromBody] CreateDepartmentCommand command)
    {
        CreatedDepartmentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedDepartmentResponse>> Update([FromBody] UpdateDepartmentCommand command)
    {
        UpdatedDepartmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedDepartmentResponse>> Delete([FromRoute] int id)
    {
        DeleteDepartmentCommand command = new() { Id = id };

        DeletedDepartmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdDepartmentResponse>> GetById([FromRoute] int id)
    {
        GetByIdDepartmentQuery query = new() { Id = id };

        GetByIdDepartmentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListDepartmentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDepartmentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListDepartmentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet("{departmentId}/doctors")]
    public async Task<IActionResult> GetDoctorsByDepartmentId([FromRoute] int departmentId,[FromQuery] PageRequest pageRequest)
    {
        GetDoctorsByDepartmentIdQuery query = new() { DepartmentID = departmentId, PageRequest = pageRequest };

        GetListResponse<GetDoctorsByDepartmentIdListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{departmentId}/available-doctors")]
    public async Task<IActionResult> GetAvailableDoctors([FromRoute]int departmentId,[FromQuery] Guid? doctorID,[FromQuery] DateOnly? date)
    {
       var query = new GetAvailableDoctorsQuery()
       {
           DepartmentID = departmentId,
           Date = date,
           DoctorID = doctorID
       };

        var response = await Mediator.Send(query);
        return Ok(response);
    }
}
