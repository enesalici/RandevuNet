using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Commands.Delete;
using Application.Features.Cities.Commands.Update;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Cities.Queries.GetDistrictsByCityId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCityResponse>> Add([FromBody] CreateCityCommand command)
    {
        CreatedCityResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCityResponse>> Update([FromBody] UpdateCityCommand command)
    {
        UpdatedCityResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCityResponse>> Delete([FromRoute] int id)
    {
        DeleteCityCommand command = new() { Id = id };

        DeletedCityResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCityResponse>> GetById([FromRoute] int id)
    {
        GetByIdCityQuery query = new() { Id = id };

        GetByIdCityResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCityQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCityQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCityListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet("{cityId}/districts")]
    public async Task<IActionResult> GetDistrictsByCityId([FromRoute] int cityId, [FromQuery] PageRequest pageRequest)
    {
        var query = new GetDistrictsByCityIdQuery() { CityId = cityId, PageRequest = pageRequest };
        GetListResponse<GetDistrictsByCityIdListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}
