using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalAddresses.Commands.Create;

public class CreatedHospitalAddressResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public int QuarterID { get; set; }
    public int HospitalID { get; set; }
}