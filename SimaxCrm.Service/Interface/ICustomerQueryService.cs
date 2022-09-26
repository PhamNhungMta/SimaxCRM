using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ICustomerQueryService
    {
        List<CustomerQuery> List();
        CustomerQuery ById(int id);
        void Create(CustomerQuery serviceType, bool hasTid = true);
        void Update(CustomerQuery serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<CustomerQuery, bool>> predicate);
        List<CustomerQuery> ByAgentIdForProperty(string createdBy, bool hasTid = true);
    }
}
