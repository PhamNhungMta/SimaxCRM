using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadLanguageService : ILeadLanguageService
    {
        private readonly ILeadLanguageRepository _leadLanguageRepository;
        public LeadLanguageService(ILeadLanguageRepository leadLanguageRepository)
        {
            _leadLanguageRepository = leadLanguageRepository;
        }

        public void Create(LeadLanguage leadLanguage)
        {
            _leadLanguageRepository.Insert(leadLanguage);
        }

        public void Delete(int id)
        {
            var obj = _leadLanguageRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadLanguageRepository.Delete(obj);
        }

        public void Update(LeadLanguage leadLanguage)
        {
            _leadLanguageRepository.UpdateEntity(leadLanguage);
        }

        public List<LeadLanguage> List()
        {
            return _leadLanguageRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadLanguage ById(int id)
        {
            return _leadLanguageRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadLanguage, bool>> predicate)
        {
            return _leadLanguageRepository.SearchFor().Any(predicate);
        }
    }
}
