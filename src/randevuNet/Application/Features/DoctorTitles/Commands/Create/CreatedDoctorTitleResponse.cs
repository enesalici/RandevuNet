using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorTitles.Commands.Create;

public class CreatedDoctorTitleResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LevelIndex { get; set; }

}