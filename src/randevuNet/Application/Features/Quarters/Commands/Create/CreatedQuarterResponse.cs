using NArchitecture.Core.Application.Responses;

namespace Application.Features.Quarters.Commands.Create;

public class CreatedQuarterResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DistrictID { get; set; }
}