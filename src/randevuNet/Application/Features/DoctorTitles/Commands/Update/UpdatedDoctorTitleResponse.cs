using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorTitles.Commands.Update;

public class UpdatedDoctorTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LevelIndex { get; set; }

}