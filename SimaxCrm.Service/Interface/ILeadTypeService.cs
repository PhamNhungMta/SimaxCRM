using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadTypeService
    {
        List<LeadType> List();
        LeadType ById(int id);
        void Create(LeadType serviceType);
        void Update(LeadType serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<LeadType, bool>> predicate);
    }
}
