using NArchitecture.Core.Application.Responses;

namespace Application.Features.Hospitals.Queries.GetById;

public class GetByIdHospitalResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int HospitalAddressID { get; set; }
}