using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadTagService : ILeadTagService
    {
        private readonly ILeadTagRepository _leadTagRepository;
        public LeadTagService(ILeadTagRepository leadTagRepository)
        {
            _leadTagRepository = leadTagRepository;
        }

        public void Create(LeadTag leadTag, bool hasTid = true)
        {
            _leadTagRepository.Insert(leadTag, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _leadTagRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadTagRepository.Delete(obj);
        }

        public void Update(LeadTag leadTag)
        {
            _leadTagRepository.UpdateEntity(leadTag);
        }

        public List<LeadTag> List()
        {
            return _leadTagRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadTag ById(int id)
        {
            return _leadTagRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadTag, bool>> predicate)
        {
            return _leadTagRepository.SearchFor().Any(predicate);
        }
    }
}
