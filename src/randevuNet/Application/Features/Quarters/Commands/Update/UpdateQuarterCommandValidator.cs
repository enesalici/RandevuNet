using FluentValidation;

namespace Application.Features.Quarters.Commands.Update;

public class UpdateQuarterCommandValidator : AbstractValidator<UpdateQuarterCommand>
{
    public UpdateQuarterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.DistrictID).NotEmpty();
    }
}