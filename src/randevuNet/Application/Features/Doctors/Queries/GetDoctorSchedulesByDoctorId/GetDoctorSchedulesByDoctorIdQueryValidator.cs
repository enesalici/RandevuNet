using FluentValidation;

namespace Application.Features.Doctors.Queries.GetDoctorSchedulesByDoctorId;

public class GetDoctorSchedulesByDoctorIdQueryValidator : AbstractValidator<GetDoctorSchedulesByDoctorIdQuery>
{
    public GetDoctorSchedulesByDoctorIdQueryValidator() { }
}