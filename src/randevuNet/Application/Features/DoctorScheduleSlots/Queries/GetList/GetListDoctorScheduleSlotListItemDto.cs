using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DoctorScheduleSlots.Queries.GetList;

public class GetListDoctorScheduleSlotListItemDto : IDto
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Guid DoctorID { get; set; }
}