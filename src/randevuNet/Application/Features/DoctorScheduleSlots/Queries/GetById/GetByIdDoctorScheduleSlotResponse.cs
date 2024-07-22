using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorScheduleSlots.Queries.GetById;

public class GetByIdDoctorScheduleSlotResponse : IResponse
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Guid DoctorID { get; set; }
}