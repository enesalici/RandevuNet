using FluentValidation;

namespace Application.Features.AppointmentReports.Commands.Delete;

public class DeleteAppointmentReportCommandValidator : AbstractValidator<DeleteAppointmentReportCommand>
{
    public DeleteAppointmentReportCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}