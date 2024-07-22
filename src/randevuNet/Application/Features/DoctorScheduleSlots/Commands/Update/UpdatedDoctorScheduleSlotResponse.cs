using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorScheduleSlots.Commands.Update;

public class UpdatedDoctorScheduleSlotResponse : IResponse
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Guid DoctorID { get; set; }
}