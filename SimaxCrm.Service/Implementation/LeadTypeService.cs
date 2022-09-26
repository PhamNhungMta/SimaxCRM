using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadTypeService : ILeadTypeService
    {
        private readonly ILeadTypeRepository _leadTypeRepository;
        public LeadTypeService(ILeadTypeRepository leadTypeRepository)
        {
            _leadTypeRepository = leadTypeRepository;
        }

        public void Create(LeadType leadType)
        {
            _leadTypeRepository.Insert(leadType);
        }

        public void Delete(int id)
        {
            var obj = _leadTypeRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadTypeRepository.Delete(obj);
        }

        public void Update(LeadType leadType)
        {
            _leadTypeRepository.UpdateEntity(leadType);
        }

        public List<LeadType> List()
        {
            return _leadTypeRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadType ById(int id)
        {
            return _leadTypeRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<LeadType, bool>> predicate)
        {
            return _leadTypeRepository.SearchFor().Any(predicate);
        }
    }
}
