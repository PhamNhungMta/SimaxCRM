using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IEmailSentService
    {
        List<EmailSent> List();
        EmailSent ById(int id);
        void Create(EmailSent serviceType);
        void Update(EmailSent serviceType);
        void Delete(int id);
    }
}
