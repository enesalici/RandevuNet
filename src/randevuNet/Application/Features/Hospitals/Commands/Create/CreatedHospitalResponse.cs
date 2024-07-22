using NArchitecture.Core.Application.Responses;

namespace Application.Features.Hospitals.Commands.Create;

public class CreatedHospitalResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

}