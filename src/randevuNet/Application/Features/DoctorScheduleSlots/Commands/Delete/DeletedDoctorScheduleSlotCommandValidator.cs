using FluentValidation;

namespace Application.Features.DoctorScheduleSlots.Commands.Delete;

public class DeleteDoctorScheduleSlotCommandValidator : AbstractValidator<DeleteDoctorScheduleSlotCommand>
{
    public DeleteDoctorScheduleSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}