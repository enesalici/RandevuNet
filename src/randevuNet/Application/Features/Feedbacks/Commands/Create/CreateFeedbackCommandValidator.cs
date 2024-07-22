using FluentValidation;

namespace Application.Features.Feedbacks.Commands.Create;

public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
{
    public CreateFeedbackCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.UserID).NotEmpty();
    }
}