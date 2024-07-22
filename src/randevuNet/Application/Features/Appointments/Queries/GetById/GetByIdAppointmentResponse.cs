using NArchitecture.Core.Application.Responses;
using Domain.Enums;

namespace Application.Features.Appointments.Queries.GetById;

public class GetByIdAppointmentResponse : IResponse
{
    public Guid Id { get; set; }
    public string DoctorTitle { get; set; }
    public string DoctorFirstName { get; set; }
    public string DoctorLastName { get; set; }

    public string PatientFirstName { get; set; }
    public string PatientLastName { get; set; }
    public string PatientEmail { get; set; }

    public string HospitalName { get; set; }
    public string DepartmentName { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public AppointmentStatus Status { get; set; }

    public Guid PatientId { get; set; }
    public Guid DoctorId { get; set; }
    public int DoctorScheduleSlotId { get; set; }
}