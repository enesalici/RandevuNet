using Application.Features.Countries.Commands.Create;
using Application.Features.Countries.Commands.Delete;
using Application.Features.Countries.Commands.Update;
using Application.Features.Countries.Queries.GetById;
using Application.Features.Countries.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Countries.Queries.GetCitiesByCountryId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountriesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCountryResponse>> Add([FromBody] CreateCountryCommand command)
    {
        CreatedCountryResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCountryResponse>> Update([FromBody] UpdateCountryCommand command)
    {
        UpdatedCountryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCountryResponse>> Delete([FromRoute] int id)
    {
        DeleteCountryCommand command = new() { Id = id };

        DeletedCountryResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCountryResponse>> GetById([FromRoute] int id)
    {
        GetByIdCountryQuery query = new() { Id = id };

        GetByIdCountryResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListCountryListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCountryQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCountryListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
    
    [HttpGet("{countryId}/cities")]
    public async Task<IActionResult> GetCitiesByCountryId([FromRoute] int countryId, [FromQuery] PageRequest pageRequest)
    {
        var query = new GetCitiesByCountryIdQuery() {CountryId = countryId, PageRequest= pageRequest };
        GetListResponse<GetCitiesByCountryIdListItemDto> response = await Mediator.Send(query);
        return Ok(response);
    }
}
