using NArchitecture.Core.Application.Responses;

namespace Application.Features.HospitalAddresses.Queries.GetById;

public class GetByIdHospitalAddressResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public int HospitalID { get; set; }
    public string HospitalName { get; set; }
    public int QuarterID { get; set; }
    public string QuarterName { get; set; }
    public int DistrictID { get; set; }
    public string DistrictName { get; set; }
    public int CityID { get; set; }
    public string CityName { get; set; }
    public int CountryID { get; set; }
    public string CountryName { get; set; }
}