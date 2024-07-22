using FluentValidation;

namespace Application.Features.Doctors.Commands.Update;

public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
{
    public UpdateDoctorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DoctorTitleID).NotEmpty();
        RuleFor(c => c.HospitalDepartmentID).NotEmpty();
    }
}