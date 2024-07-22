using FluentValidation;

namespace Application.Features.Feedbacks.Commands.Update;

public class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
{
    public UpdateFeedbackCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.UserID).NotEmpty();
    }
}