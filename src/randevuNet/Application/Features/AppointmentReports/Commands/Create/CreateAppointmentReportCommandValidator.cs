using FluentValidation;

namespace Application.Features.AppointmentReports.Commands.Create;

public class CreateAppointmentReportCommandValidator : AbstractValidator<CreateAppointmentReportCommand>
{
    public CreateAppointmentReportCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Detail).NotEmpty();
        RuleFor(c => c.AppointmentID).NotEmpty();
    }
}