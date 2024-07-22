using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Departments.Queries.GetList;

public class GetListDepartmentListItemDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}