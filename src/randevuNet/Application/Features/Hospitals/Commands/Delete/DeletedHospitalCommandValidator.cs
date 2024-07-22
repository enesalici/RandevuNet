using FluentValidation;

namespace Application.Features.Hospitals.Commands.Delete;

public class DeleteHospitalCommandValidator : AbstractValidator<DeleteHospitalCommand>
{
    public DeleteHospitalCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}