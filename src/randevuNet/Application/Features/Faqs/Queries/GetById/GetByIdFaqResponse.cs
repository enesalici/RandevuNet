using NArchitecture.Core.Application.Responses;

namespace Application.Features.Faqs.Queries.GetById;

public class GetByIdFaqResponse : IResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
}