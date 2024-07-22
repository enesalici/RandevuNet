using FluentValidation;

namespace Application.Features.DoctorTitles.Commands.Update;

public class UpdateDoctorTitleCommandValidator : AbstractValidator<UpdateDoctorTitleCommand>
{
    public UpdateDoctorTitleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.LevelIndex).NotEmpty();
    }
}