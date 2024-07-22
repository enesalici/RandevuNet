using NArchitecture.Core.Application.Responses;

namespace Application.Features.DoctorTitles.Commands.Delete;

public class DeletedDoctorTitleResponse : IResponse
{
    public int Id { get; set; }
}