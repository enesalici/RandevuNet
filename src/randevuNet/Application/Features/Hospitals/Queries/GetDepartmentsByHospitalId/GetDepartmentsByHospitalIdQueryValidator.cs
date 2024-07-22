using FluentValidation;

namespace Application.Features.Hospitals.Queries.GetDepartmentsByHospitalId;

public class GetDepartmentsByHospitalIdQueryValidator : AbstractValidator<GetDepartmentsByHospitalIdQuery>
{
    public GetDepartmentsByHospitalIdQueryValidator() { }
}