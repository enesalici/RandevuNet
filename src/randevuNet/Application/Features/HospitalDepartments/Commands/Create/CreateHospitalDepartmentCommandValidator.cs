using FluentValidation;

namespace Application.Features.HospitalDepartments.Commands.Create;

public class CreateHospitalDepartmentCommandValidator : AbstractValidator<CreateHospitalDepartmentCommand>
{
    public CreateHospitalDepartmentCommandValidator()
    {
        RuleFor(c => c.HospitalID).NotEmpty();
        RuleFor(c => c.DepartmentID).NotEmpty();
    }
}