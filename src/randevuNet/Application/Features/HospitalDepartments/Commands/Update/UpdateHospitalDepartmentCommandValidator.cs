using FluentValidation;

namespace Application.Features.HospitalDepartments.Commands.Update;

public class UpdateHospitalDepartmentCommandValidator : AbstractValidator<UpdateHospitalDepartmentCommand>
{
    public UpdateHospitalDepartmentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.HospitalID).NotEmpty();
        RuleFor(c => c.DepartmentID).NotEmpty();
    }
}