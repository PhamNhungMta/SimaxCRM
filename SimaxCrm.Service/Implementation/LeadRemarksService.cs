using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class LeadRemarksService : ILeadRemarksService
    {
        private readonly ILeadRemarksRepository _leadRemarksRepository;
        public LeadRemarksService(ILeadRemarksRepository leadRemarksRepository)
        {
            _leadRemarksRepository = leadRemarksRepository;
        }

        public void Create(LeadRemarks leadRemarks, bool hasTid = true)
        {
            _leadRemarksRepository.Insert(leadRemarks, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _leadRemarksRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadRemarksRepository.Delete(obj);
        }

        public void Update(LeadRemarks leadRemarks)
        {
            _leadRemarksRepository.UpdateEntity(leadRemarks);
        }

        public List<LeadRemarks> List()
        {
            return _leadRemarksRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadRemarks ById(int id)
        {
            return _leadRemarksRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<LeadRemarks> ByStatus(string status)
        {
            return _leadRemarksRepository.SearchFor(x => x.Status == status).ToList();
        }
    }
}
