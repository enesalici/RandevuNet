using FluentValidation;

namespace Application.Features.Quarters.Commands.Delete;

public class DeleteQuarterCommandValidator : AbstractValidator<DeleteQuarterCommand>
{
    public DeleteQuarterCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}