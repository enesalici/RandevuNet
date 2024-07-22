using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Countries.Queries.GetCitiesByCountryId;

public class GetCitiesByCountryIdListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}
