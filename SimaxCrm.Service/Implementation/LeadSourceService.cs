using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadSourceService : ILeadSourceService
    {
        private readonly ILeadSourceRepository _leadSourceRepository;
        public LeadSourceService(ILeadSourceRepository leadSourceRepository)
        {
            _leadSourceRepository = leadSourceRepository;
        }

        public void Create(LeadSource leadSource, bool hasTid = true)
        {
            _leadSourceRepository.Insert(leadSource, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _leadSourceRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadSourceRepository.Delete(obj);
        }

        public void Update(LeadSource leadSource)
        {
            _leadSourceRepository.UpdateEntity(leadSource);
        }

        public List<LeadSource> List()
        {
            return _leadSourceRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadSource ById(int id)
        {
            return _leadSourceRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadSource, bool>> predicate)
        {
            return _leadSourceRepository.SearchFor().Any(predicate);
        }

        public LeadSource ByName(string source)
        {
            return _leadSourceRepository.SearchFor(x => x.Name == source).FirstOrDefault();
        }

        public LeadSource ByNameAndTid(string source, int tid)
        {
            return _leadSourceRepository.SearchFor(x => x.Name == source && x.Tid == tid, hasTid: false).FirstOrDefault();
        }
    }
}
