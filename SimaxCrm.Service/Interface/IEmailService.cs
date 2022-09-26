using AE.Net.Mail;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IEmailService
    {
        List<MailMessage> GetMails(EmailSetup emailSetup, EmailBoxType emailBoxType);
        MailMessage GetInboxMailById(EmailSetup emailSetup, string emailId);
    }
}
