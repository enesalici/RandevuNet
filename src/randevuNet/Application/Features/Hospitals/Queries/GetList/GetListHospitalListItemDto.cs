using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Hospitals.Queries.GetList;

public class GetListHospitalListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}