using FluentValidation;

namespace Application.Features.DoctorScheduleSlots.Commands.Update;

public class UpdateDoctorScheduleSlotCommandValidator : AbstractValidator<UpdateDoctorScheduleSlotCommand>
{
    public UpdateDoctorScheduleSlotCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.StartTime).NotEmpty();
        RuleFor(c => c.EndTime).NotEmpty();
        RuleFor(c => c.DoctorID).NotEmpty();
    }
}