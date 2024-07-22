using FluentValidation;

namespace Application.Features.Departments.Commands.Delete;

public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}