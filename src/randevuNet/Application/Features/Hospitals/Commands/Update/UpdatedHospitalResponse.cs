using NArchitecture.Core.Application.Responses;

namespace Application.Features.Hospitals.Commands.Update;

public class UpdatedHospitalResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}