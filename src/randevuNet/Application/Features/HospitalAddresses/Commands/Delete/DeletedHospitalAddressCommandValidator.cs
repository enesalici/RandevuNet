using FluentValidation;

namespace Application.Features.HospitalAddresses.Commands.Delete;

public class DeleteHospitalAddressCommandValidator : AbstractValidator<DeleteHospitalAddressCommand>
{
    public DeleteHospitalAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}