using NArchitecture.Core.Application.Responses;

namespace Application.Features.Hospitals.Commands.Delete;

public class DeletedHospitalResponse : IResponse
{
    public int Id { get; set; }
}