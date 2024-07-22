using NArchitecture.Core.Application.Responses;

namespace Application.Features.Faqs.Commands.Create;

public class CreatedFaqResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}