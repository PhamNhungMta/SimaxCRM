using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IEmailSetupService
    {
        List<EmailSetup> List();
        EmailSetup ById(int id);
        void Create(EmailSetup serviceType);
        void Update(EmailSetup serviceType);
        void Delete(int id);
    }
}
