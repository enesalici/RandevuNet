using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Quarters.Queries.GetList;

public class GetListQuarterListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DistrictID { get; set; }
    public string DistrictName { get; set; }
    public int CityID { get; set; }
    public string CityName { get; set; }
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}