using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class CustomerQueryService : ICustomerQueryService
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public CustomerQueryService(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public void Create(CustomerQuery customerQuery, bool hasTid = true)
        {
            _customerQueryRepository.Insert(customerQuery, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _customerQueryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _customerQueryRepository.Delete(obj);
        }

        public void Update(CustomerQuery customerQuery)
        {
            _customerQueryRepository.UpdateEntity(customerQuery);
        }

        public List<CustomerQuery> List()
        {
            return _customerQueryRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public CustomerQuery ById(int id)
        {
            return _customerQueryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<CustomerQuery, bool>> predicate)
        {
            return _customerQueryRepository.SearchFor().Any(predicate);
        }

        public List<CustomerQuery> ByAgentIdForProperty(string createdBy, bool hasTid = true)
        {
            return _customerQueryRepository.SearchFor(null, "Product", hasTid: hasTid).Where(m => m.Product != null && m.Product.CreatedBy == createdBy).ToList();
        }
    }
}
