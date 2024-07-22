using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorTitles.Queries.GetById;

public class GetByIdDoctorTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LevelIndex { get; set; }

}