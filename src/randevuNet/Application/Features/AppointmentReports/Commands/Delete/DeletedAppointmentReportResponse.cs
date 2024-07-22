using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppointmentReports.Commands.Delete;

public class DeletedAppointmentReportResponse : IResponse
{
    public int Id { get; set; }
}