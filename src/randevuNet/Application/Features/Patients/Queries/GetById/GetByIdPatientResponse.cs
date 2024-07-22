using NArchitecture.Core.Application.Responses;

namespace Application.Features.Patients.Queries.GetById;

public class GetByIdPatientResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePhoto { get; set; }
    public int UserRoleID { get; set; }

}