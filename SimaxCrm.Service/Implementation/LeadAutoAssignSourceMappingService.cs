using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class LeadAutoAssignSourceMappingService : ILeadAutoAssignSourceMappingService
    {
        private readonly ILeadAutoAssignSourceMappingRepository _leadAutoAssignSourceMappingRepository;
        public LeadAutoAssignSourceMappingService(ILeadAutoAssignSourceMappingRepository leadAutoAssignSourceMappingRepository)
        {
            _leadAutoAssignSourceMappingRepository = leadAutoAssignSourceMappingRepository;
        }

        public void Create(LeadAutoAssignSourceMapping leadAutoAssignSourceMapping)
        {
            _leadAutoAssignSourceMappingRepository.Insert(leadAutoAssignSourceMapping);
        }

        public void Delete(int id)
        {
            var obj = _leadAutoAssignSourceMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadAutoAssignSourceMappingRepository.Delete(obj);
        }

        public void Update(LeadAutoAssignSourceMapping leadAutoAssignSourceMapping)
        {
            _leadAutoAssignSourceMappingRepository.UpdateEntity(leadAutoAssignSourceMapping);
        }

        public List<LeadAutoAssignSourceMapping> List()
        {
            return _leadAutoAssignSourceMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadAutoAssignSourceMapping ById(int id)
        {
            return _leadAutoAssignSourceMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<LeadAutoAssignSourceMapping> ByLeadAutoAssignId(int leadAutoAssignId)
        {
            return _leadAutoAssignSourceMappingRepository.SearchFor(m => m.LeadAutoAssignId == leadAutoAssignId).ToList();
        }
    }
}
