using NArchitecture.Core.Application.Responses;

namespace Application.Features.Faqs.Commands.Update;

public class UpdatedFaqResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}