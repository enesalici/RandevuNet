using NArchitecture.Core.Application.Dtos;

namespace Application.Features.AppointmentReports.Queries.GetList;

public class GetListAppointmentReportListItemDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public Guid AppointmentID { get; set; }
}