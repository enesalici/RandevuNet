using FluentValidation;

namespace Application.Features.DoctorTitles.Commands.Create;

public class CreateDoctorTitleCommandValidator : AbstractValidator<CreateDoctorTitleCommand>
{
    public CreateDoctorTitleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.LevelIndex).NotEmpty();
    }
}