using FluentValidation;

namespace Application.Features.DoctorScheduleSlots.Commands.Create;

public class CreateDoctorScheduleSlotCommandValidator : AbstractValidator<CreateDoctorScheduleSlotCommand>
{
    public CreateDoctorScheduleSlotCommandValidator()
    {
        RuleFor(c => c.Date).NotEmpty();
        RuleFor(c => c.StartTime).NotEmpty();
        RuleFor(c => c.EndTime).NotEmpty();
        RuleFor(c => c.DoctorID).NotEmpty();
    }
}