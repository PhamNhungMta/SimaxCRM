using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using SimaxCrm.Model.Entity;
using System.Linq.Expressions;
using System;

namespace SimaxCrm.Service.Implementation
{
    public class LeadOrderService : ILeadOrderService
    {
        private readonly ILeadOrderRepository _leadOrderRepository;
        public LeadOrderService(ILeadOrderRepository leadOrderRepository)
        {
            _leadOrderRepository = leadOrderRepository;
        }

        public void Create(LeadOrder leadOrder)
        {
            _leadOrderRepository.Insert(leadOrder);
        }

        public void Delete(int id)
        {
            var obj = _leadOrderRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadOrderRepository.Delete(obj);
        }

        public void Update(LeadOrder leadOrder)
        {
            _leadOrderRepository.UpdateEntity(leadOrder);
        }

        public List<LeadOrder> List(bool hasTid = true)
        {
            return _leadOrderRepository.SearchFor(null, "LeadOrderDetail", hasTid: hasTid).OrderByDescending(x => x.Id).ToList();
        }

        public LeadOrder ById(int id)
        {
            return _leadOrderRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<LeadOrder> ByUserId(string userId)
        {
            return _leadOrderRepository.SearchFor(x => x.UserId == userId, "LeadOrderDetail").ToList();
        }
    }
}
