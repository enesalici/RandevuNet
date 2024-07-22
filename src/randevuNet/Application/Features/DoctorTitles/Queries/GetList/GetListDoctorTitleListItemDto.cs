using NArchitecture.Core.Application.Dtos;

namespace Application.Features.DoctorTitles.Queries.GetList;

public class GetListDoctorTitleListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LevelIndex { get; set; }

}