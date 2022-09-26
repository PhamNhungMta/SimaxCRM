using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using SimaxCrm.Model.Entity;
using System.Linq.Expressions;
using System;

namespace SimaxCrm.Service.Implementation
{
    public class TcfService : ITcfService
    {
        private readonly ITcfRepository _tcfRepository;
        public TcfService(ITcfRepository tcfRepository)
        {
            _tcfRepository = tcfRepository;
        }

        public void Create(Tcf tcf)
        {
            _tcfRepository.Insert(tcf);
        }

        public void Delete(int id)
        {
            var obj = _tcfRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _tcfRepository.Delete(obj);
        }

        public void Update(Tcf tcf)
        {
            _tcfRepository.UpdateEntity(tcf);
        }

        public List<Tcf> List()
        {
            return _tcfRepository.SearchFor(null, "Lead").OrderByDescending(x => x.Id).ToList();
        }

        public Tcf ById(int id)
        {
            return _tcfRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public Tcf ByLeadId(int leadId)
        {
            return _tcfRepository.SearchFor(x => x.LeadId == leadId, hasTracking: false).FirstOrDefault();
        }
    }
}
