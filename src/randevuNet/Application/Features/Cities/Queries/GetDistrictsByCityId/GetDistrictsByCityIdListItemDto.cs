using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cities.Queries.GetDistrictsByCityId;

public class GetDistrictsByCityIdListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityID { get; set; }
    public string CityName { get; set; }
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}
