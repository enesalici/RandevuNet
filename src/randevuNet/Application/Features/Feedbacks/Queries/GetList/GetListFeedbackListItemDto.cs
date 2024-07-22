using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Feedbacks.Queries.GetList;

public class GetListFeedbackListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public Guid UserID { get; set; }
}