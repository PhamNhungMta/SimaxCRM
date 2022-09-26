using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadProductMappingService
    {
        List<LeadProductMapping> List();
        LeadProductMapping ById(int id);
        void Create(LeadProductMapping serviceType, bool hasTid = true);
        void Update(LeadProductMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<LeadProductMapping, bool>> predicate);
        List<LeadProductMapping> ByLeadId(int leadId);
    }
}
