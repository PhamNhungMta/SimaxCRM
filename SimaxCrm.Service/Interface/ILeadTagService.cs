using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadTagService
    {
        List<LeadTag> List();
        LeadTag ById(int id);
        void Create(LeadTag serviceType, bool hasTid = true);
        void Update(LeadTag serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<LeadTag, bool>> predicate);
    }
}
