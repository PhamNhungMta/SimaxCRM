using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadTagMappingService
    {
        List<LeadTagMapping> List();
        LeadTagMapping ById(int id);
        void Create(LeadTagMapping serviceType);
        void Update(LeadTagMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<LeadTagMapping, bool>> predicate);
        List<LeadTagMapping> ByLeadId(int leadId);
    }
}
