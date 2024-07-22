using FluentValidation;

namespace Application.Features.Quarters.Commands.Create;

public class CreateQuarterCommandValidator : AbstractValidator<CreateQuarterCommand>
{
    public CreateQuarterCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DistrictID).NotEmpty();
    }
}