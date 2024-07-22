using FluentValidation;

namespace Application.Features.Hospitals.Commands.Create;

public class CreateHospitalCommandValidator : AbstractValidator<CreateHospitalCommand>
{
    public CreateHospitalCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}