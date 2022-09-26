using AE.Net.Mail;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class EmailService : IEmailService
    {
        private ImapClient login(EmailSetup emailSetup)
        {
            return new ImapClient(emailSetup.IncommingMailServer, emailSetup.Username, emailSetup.Password, AuthMethods.Login, Convert.ToInt32(emailSetup.IncommingMailPort), emailSetup.UseSsl == "Yes");
        }

        public List<MailMessage> GetMails(EmailSetup emailSetup, EmailBoxType emailBoxType)
        {
            var ic = login(emailSetup);
            int msgcount = ic.GetMessageCount(emailBoxType.ToString());
            int end = msgcount - 1;
            int start = msgcount - 200;
            MailMessage[] mm = ic.GetMessages(start, end, false);
            return mm.ToList();
        }

        public MailMessage GetInboxMailById(EmailSetup emailSetup, string emailId)
        {
            var ic = login(emailSetup);
            MailMessage mm = ic.GetMessage(emailId, false);
            return mm;
        }

       
    }
}