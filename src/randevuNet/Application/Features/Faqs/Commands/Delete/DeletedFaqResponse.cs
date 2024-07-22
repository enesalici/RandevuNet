using NArchitecture.Core.Application.Responses;

namespace Application.Features.Faqs.Commands.Delete;

public class DeletedFaqResponse : IResponse
{
    public int Id { get; set; }
}