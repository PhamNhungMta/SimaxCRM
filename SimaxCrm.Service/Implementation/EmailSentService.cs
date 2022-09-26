using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class EmailSentService : IEmailSentService
    {
        private readonly IEmailSentRepository _emailSentRepository;
        public EmailSentService(IEmailSentRepository emailSentRepository)
        {
            _emailSentRepository = emailSentRepository;
        }

        public void Create(EmailSent emailSent)
        {
            _emailSentRepository.Insert(emailSent);
        }

        public void Delete(int id)
        {
            var obj = _emailSentRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _emailSentRepository.Delete(obj);
        }

        public void Update(EmailSent emailSent)
        {
            _emailSentRepository.UpdateEntity(emailSent);
        }

        public List<EmailSent> List()
        {
            return _emailSentRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public EmailSent ById(int id)
        {
            return _emailSentRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }
    }
}
