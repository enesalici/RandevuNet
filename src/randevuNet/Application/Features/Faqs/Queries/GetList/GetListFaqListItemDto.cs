using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Faqs.Queries.GetList;

public class GetListFaqListItemDto : IDto
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}