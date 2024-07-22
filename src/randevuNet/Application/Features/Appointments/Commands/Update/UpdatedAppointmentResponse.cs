using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Appointments.Commands.Update;

public class UpdatedAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
    public AppointmentStatus Status { get; set; }
    public Guid PatientId { get; set; }
    public int DoctorScheduleSlotId { get; set; }
}