using FluentValidation;

namespace Application.Features.HospitalDepartments.Commands.Delete;

public class DeleteHospitalDepartmentCommandValidator : AbstractValidator<DeleteHospitalDepartmentCommand>
{
    public DeleteHospitalDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}