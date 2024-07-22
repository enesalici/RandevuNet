using FluentValidation;

namespace Application.Features.AppointmentReports.Commands.Update;

public class UpdateAppointmentReportCommandValidator : AbstractValidator<UpdateAppointmentReportCommand>
{
    public UpdateAppointmentReportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Detail).NotEmpty();
        RuleFor(c => c.AppointmentID).NotEmpty();
    }
}