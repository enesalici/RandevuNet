using FluentValidation;

namespace Application.Features.Departments.Queries.GetDoctorsByDepartmentId;

public class GetDoctorsByDepartmentIdQueryValidator : AbstractValidator<GetDoctorsByDepartmentIdQuery>
{
    public GetDoctorsByDepartmentIdQueryValidator() { }
}