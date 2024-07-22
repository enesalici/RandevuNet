using Application.Services.MailService;
using Microsoft.Extensions.Options;
using MimeKit;
using NArchitecture.Core.Mailing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters.MailService;
public class AppointmentInfoMailAdapter : AppointmentMailBase
{
    public AppointmentInfoMailAdapter(AppoinmentMailOptions options) : base(options)
    {
        ToList=options.ToList;
        Subject = options.Subject;
        HtmlBody = getHtmlTemplate(options);
    }

    public AppointmentInfoMailAdapter(AppoinmentMailOptions options, string subject, string textBody, string htmlBody, List<MailboxAddress> toList) : base(options, subject, textBody, htmlBody, toList)
    {
    }

    string getHtmlTemplate(AppoinmentMailOptions options)
    {
        return @$"
<div style=""background-color:#2F2F75;color:white;padding:5px;border-radius:20px;margin-bottom:15px"">
<center><h3>RandevuNet | Randevu Bilgileri</h3></center>
</div>

<div style=""background-color:#2F2F75;color:white;padding: 20px;border-radius: 20px;"">
<div><b> Sn. {options.PatientFirstName} {options.PatientLastName}</b></div>

<br />
<div>
<b>{options.HospitalName}</b> hastanesi 
<br />
<b>{options.DepartmentName}</b> polikliniği 
<br />
<b>{options.DoctorTitle} {options.DoctorFirstName} {options.DoctorLastName}</b> hekimine 
<br />
<b>{options.Date} Saat: {options.StartTime} - {options.EndTime}</b> tarihli 
<br />
muayene randevunuza ait bilgilerdir.
</div>
<br />
<small>RandevuNet</small>
</div>
";
    }


}
