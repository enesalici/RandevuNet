using FluentValidation;

namespace Application.Features.Doctors.Commands.Create;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    public CreateDoctorCommandValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DoctorTitleID).NotEmpty();
        RuleFor(c => c.HospitalDepartmentID).NotEmpty();
    }
}