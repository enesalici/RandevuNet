using FluentValidation;

namespace Application.Features.UserRoles.Commands.Delete;

public class DeleteUserRoleCommandValidator : AbstractValidator<DeleteUserRoleCommand>
{
    public DeleteUserRoleCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}