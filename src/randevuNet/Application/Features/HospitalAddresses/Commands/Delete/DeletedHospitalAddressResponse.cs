using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalAddresses.Commands.Delete;

public class DeletedHospitalAddressResponse : IResponse
{
    public int Id { get; set; }
}