using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorScheduleSlots.Commands.Delete;

public class DeletedDoctorScheduleSlotResponse : IResponse
{
    public int Id { get; set; }
}