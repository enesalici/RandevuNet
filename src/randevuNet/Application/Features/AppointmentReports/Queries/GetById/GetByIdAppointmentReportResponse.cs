using NArchitecture.Core.Application.Responses;

namespace Application.Features.AppointmentReports.Queries.GetById;

public class GetByIdAppointmentReportResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public Guid AppointmentID { get; set; }
}