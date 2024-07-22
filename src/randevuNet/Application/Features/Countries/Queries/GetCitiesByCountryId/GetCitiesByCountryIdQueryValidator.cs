using FluentValidation;

namespace Application.Features.Countries.Queries.GetCitiesByCountryId;

public class GetCitiesByCountryIdQueryValidator : AbstractValidator<GetCitiesByCountryIdQuery>
{
    public GetCitiesByCountryIdQueryValidator() { }
}