using FluentValidation;

namespace Application.Features.Appointments.Commands.Update;

public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
{
    public UpdateAppointmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.PatientId).NotEmpty();
        RuleFor(c => c.DoctorScheduleSlotId).NotEmpty();
    }
}