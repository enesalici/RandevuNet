using FluentValidation;

namespace Application.Features.HospitalAddresses.Commands.Create;

public class CreateHospitalAddressCommandValidator : AbstractValidator<CreateHospitalAddressCommand>
{
    public CreateHospitalAddressCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Detail).NotEmpty();
        RuleFor(c => c.QuarterID).NotEmpty();
        RuleFor(c => c.HospitalID).NotEmpty();
    }
}