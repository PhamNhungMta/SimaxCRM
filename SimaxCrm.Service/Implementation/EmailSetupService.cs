using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class EmailSetupService : IEmailSetupService
    {
        private readonly IEmailSetupRepository _emailSetupRepository;
        public EmailSetupService(IEmailSetupRepository emailSetupRepository)
        {
            _emailSetupRepository = emailSetupRepository;
        }

        public void Create(EmailSetup emailSetup)
        {
            _emailSetupRepository.Insert(emailSetup);
        }

        public void Delete(int id)
        {
            var obj = _emailSetupRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _emailSetupRepository.Delete(obj);
        }

        public void Update(EmailSetup emailSetup)
        {
            _emailSetupRepository.UpdateEntity(emailSetup);
        }

        public List<EmailSetup> List()
        {
            return _emailSetupRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public EmailSetup ById(int id)
        {
            return _emailSetupRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }
    }
}
