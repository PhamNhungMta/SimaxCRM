using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadProjectMappingService
    {
        List<LeadProjectMapping> List();
        LeadProjectMapping ById(int id);
        void Create(LeadProjectMapping serviceType, bool hasTid = true);
        void Update(LeadProjectMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<LeadProjectMapping, bool>> predicate);
        List<LeadProjectMapping> ByLeadId(int leadId);
    }
}
