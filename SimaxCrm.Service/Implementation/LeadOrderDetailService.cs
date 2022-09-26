using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using SimaxCrm.Model.Entity;
using System.Linq.Expressions;
using System;

namespace SimaxCrm.Service.Implementation
{
    public class LeadOrderDetailService : ILeadOrderDetailService
    {
        private readonly ILeadOrderDetailRepository _leadOrderDetailRepository;
        public LeadOrderDetailService(ILeadOrderDetailRepository leadOrderDetailRepository)
        {
            _leadOrderDetailRepository = leadOrderDetailRepository;
        }

        public void Create(LeadOrderDetail leadOrderDetail)
        {
            _leadOrderDetailRepository.Insert(leadOrderDetail);
        }

        public void Delete(int id)
        {
            var obj = _leadOrderDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadOrderDetailRepository.Delete(obj);
        }

        public void Update(LeadOrderDetail leadOrderDetail)
        {
            _leadOrderDetailRepository.UpdateEntity(leadOrderDetail);
        }

        public List<LeadOrderDetail> List(DateTime? startDate = null, DateTime? endDate = null, bool hasTid = true)
        {
            var query = _leadOrderDetailRepository.SearchFor(null, hasTid: hasTid);

            if (startDate.HasValue)
            {
                query = query.Where(m => m.CreatedDate.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(m => m.CreatedDate.Date <= endDate.Value);
            }
            return query.ToList();
        }

        public LeadOrderDetail ById(int id)
        {
            return _leadOrderDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }
    }
}
