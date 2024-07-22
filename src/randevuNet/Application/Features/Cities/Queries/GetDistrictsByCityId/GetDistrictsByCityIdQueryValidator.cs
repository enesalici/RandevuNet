using FluentValidation;

namespace Application.Features.Cities.Queries.GetDistrictsByCityId;

public class GetDistrictsByCityIdQueryValidator : AbstractValidator<GetDistrictsByCityIdQuery>
{
    public GetDistrictsByCityIdQueryValidator() { }
}