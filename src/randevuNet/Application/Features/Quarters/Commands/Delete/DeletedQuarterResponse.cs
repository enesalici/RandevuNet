using NArchitecture.Core.Application.Responses;

namespace Application.Features.Quarters.Commands.Delete;

public class DeletedQuarterResponse : IResponse
{
    public int Id { get; set; }
}