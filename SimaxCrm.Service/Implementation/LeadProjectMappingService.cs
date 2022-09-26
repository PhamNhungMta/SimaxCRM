using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadProjectMappingService : ILeadProjectMappingService
    {
        private readonly ILeadProjectMappingRepository _leadProjectMappingRepository;
        public LeadProjectMappingService(ILeadProjectMappingRepository leadProjectMappingRepository)
        {
            _leadProjectMappingRepository = leadProjectMappingRepository;
        }

        public void Create(LeadProjectMapping leadProjectMapping, bool hasTid = true)
        {
            _leadProjectMappingRepository.Insert(leadProjectMapping, hasTid: hasTid);
        }

        public void Delete(int id)
        {
            var obj = _leadProjectMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadProjectMappingRepository.Delete(obj);
        }

        public void Update(LeadProjectMapping leadProjectMapping)
        {
            _leadProjectMappingRepository.UpdateEntity(leadProjectMapping);
        }

        public List<LeadProjectMapping> List()
        {
            return _leadProjectMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadProjectMapping ById(int id)
        {
            return _leadProjectMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadProjectMapping, bool>> predicate)
        {
            return _leadProjectMappingRepository.SearchFor().Any(predicate);
        }

        public List<LeadProjectMapping> ByLeadId(int leadId)
        {
            return _leadProjectMappingRepository.SearchFor(x => x.LeadId == leadId).ToList();
        }
    }
}
