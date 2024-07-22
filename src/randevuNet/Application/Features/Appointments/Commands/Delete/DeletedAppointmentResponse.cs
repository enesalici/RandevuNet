using NArchitecture.Core.Application.Responses;

namespace Application.Features.Appointments.Commands.Delete;

public class DeletedAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
}