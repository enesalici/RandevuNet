using NArchitecture.Core.Application.Responses;

namespace Application.Features.Feedbacks.Commands.Update;

public class UpdatedFeedbackResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public Guid UserID { get; set; }
}