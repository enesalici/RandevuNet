using FluentValidation;

namespace Application.Features.Faqs.Commands.Delete;

public class DeleteFaqCommandValidator : AbstractValidator<DeleteFaqCommand>
{
    public DeleteFaqCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}