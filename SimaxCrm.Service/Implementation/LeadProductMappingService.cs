using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadProductMappingService : ILeadProductMappingService
    {
        private readonly ILeadProductMappingRepository _leadProductMappingRepository;
        public LeadProductMappingService(ILeadProductMappingRepository leadProductMappingRepository)
        {
            _leadProductMappingRepository = leadProductMappingRepository;
        }

        public void Create(LeadProductMapping leadProductMapping, bool hasTid = true)
        {
            _leadProductMappingRepository.Insert(leadProductMapping, hasTid: hasTid);
        }

        public void Delete(int id)
        {
            var obj = _leadProductMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadProductMappingRepository.Delete(obj);
        }

        public void Update(LeadProductMapping leadProductMapping)
        {
            _leadProductMappingRepository.UpdateEntity(leadProductMapping);
        }

        public List<LeadProductMapping> List()
        {
            return _leadProductMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadProductMapping ById(int id)
        {
            return _leadProductMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadProductMapping, bool>> predicate)
        {
            return _leadProductMappingRepository.SearchFor().Any(predicate);
        }

        public List<LeadProductMapping> ByLeadId(int leadId)
        {
            return _leadProductMappingRepository.SearchFor(x => x.LeadId == leadId).ToList();
        }
    }
}
