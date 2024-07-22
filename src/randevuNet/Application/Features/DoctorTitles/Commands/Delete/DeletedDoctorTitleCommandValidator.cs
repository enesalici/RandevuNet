using FluentValidation;

namespace Application.Features.DoctorTitles.Commands.Delete;

public class DeleteDoctorTitleCommandValidator : AbstractValidator<DeleteDoctorTitleCommand>
{
    public DeleteDoctorTitleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}