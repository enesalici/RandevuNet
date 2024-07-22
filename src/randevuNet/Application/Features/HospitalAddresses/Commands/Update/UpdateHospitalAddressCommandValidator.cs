using FluentValidation;

namespace Application.Features.HospitalAddresses.Commands.Update;

public class UpdateHospitalAddressCommandValidator : AbstractValidator<UpdateHospitalAddressCommand>
{
    public UpdateHospitalAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Detail).NotEmpty();
        RuleFor(c => c.QuarterID).NotEmpty();
        RuleFor(c => c.HospitalID).NotEmpty();
    }
}