using Application.Features.HospitalAddresses.Commands.Create;
using Application.Features.HospitalAddresses.Commands.Delete;
using Application.Features.HospitalAddresses.Commands.Update;
using Application.Features.HospitalAddresses.Queries.GetById;
using Application.Features.HospitalAddresses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalAddressesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedHospitalAddressResponse>> Add([FromBody] CreateHospitalAddressCommand command)
    {
        CreatedHospitalAddressResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedHospitalAddressResponse>> Update([FromBody] UpdateHospitalAddressCommand command)
    {
        UpdatedHospitalAddressResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedHospitalAddressResponse>> Delete([FromRoute] int id)
    {
        DeleteHospitalAddressCommand command = new() { Id = id };

        DeletedHospitalAddressResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdHospitalAddressResponse>> GetById([FromRoute] int id)
    {
        GetByIdHospitalAddressQuery query = new() { Id = id };

        GetByIdHospitalAddressResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListHospitalAddressQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListHospitalAddressQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListHospitalAddressListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}