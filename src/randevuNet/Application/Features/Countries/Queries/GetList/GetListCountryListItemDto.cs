using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Countries.Queries.GetList;

public class GetListCountryListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}