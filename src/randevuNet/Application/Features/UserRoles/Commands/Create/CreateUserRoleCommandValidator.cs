using FluentValidation;

namespace Application.Features.UserRoles.Commands.Create;

public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}