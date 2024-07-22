using MimeKit;
using NArchitecture.Core.Mailing;

namespace Application.Services.MailService;
public abstract class AppointmentMailBase : Mail
{
    public AppoinmentMailOptions Options { get; }

    
    public AppointmentMailBase(AppoinmentMailOptions options) : base()
    {
        Options = options;
    }

    public AppointmentMailBase(AppoinmentMailOptions options,string subject, string textBody, string htmlBody, List<MailboxAddress> toList) : base(subject, textBody, htmlBody, toList)
    {
        Options = options;
    }

    public class AppoinmentMailOptions
    {
        public List<MailboxAddress> ToList { get; set; }
        public string Subject { get; set; }
        public string DoctorTitle { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }

        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }

        public string HospitalName { get; set; }
        public string DepartmentName { get; set; }

        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
