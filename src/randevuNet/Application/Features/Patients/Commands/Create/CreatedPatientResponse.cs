using NArchitecture.Core.Application.Responses;

namespace Application.Features.Patients.Commands.Create;

public class CreatedPatientResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfilePhoto { get; set; }
    public int UserRoleID { get; set; }

}