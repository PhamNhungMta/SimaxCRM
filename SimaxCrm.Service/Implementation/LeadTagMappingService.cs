using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadTagMappingService : ILeadTagMappingService
    {
        private readonly ILeadTagMappingRepository _leadTagMappingRepository;
        public LeadTagMappingService(ILeadTagMappingRepository leadTagMappingRepository)
        {
            _leadTagMappingRepository = leadTagMappingRepository;
        }

        public void Create(LeadTagMapping leadTagMapping)
        {
            _leadTagMappingRepository.Insert(leadTagMapping);
        }

        public void Delete(int id)
        {
            var obj = _leadTagMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadTagMappingRepository.Delete(obj);
        }

        public void Update(LeadTagMapping leadTagMapping)
        {
            _leadTagMappingRepository.UpdateEntity(leadTagMapping);
        }

        public List<LeadTagMapping> List()
        {
            return _leadTagMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadTagMapping ById(int id)
        {
            return _leadTagMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadTagMapping, bool>> predicate)
        {
            return _leadTagMappingRepository.SearchFor().Any(predicate);
        }

        public List<LeadTagMapping> ByLeadId(int leadId)
        {
            return _leadTagMappingRepository.SearchFor(x => x.LeadId == leadId).ToList();
        }
    }
}
