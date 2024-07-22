using FluentValidation;

namespace Application.Features.Appointments.Commands.Create;

public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
{
    public CreateAppointmentCommandValidator()
    {
        //RuleFor(c => c.PatientId).NotEmpty();
        //RuleFor(c => c.DoctorScheduleSlotId).NotEmpty();
    }
}