using NArchitecture.Core.Application.Responses;

namespace Application.Features.Districts.Commands.Update;

public class UpdatedDistrictResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityID { get; set; }
}