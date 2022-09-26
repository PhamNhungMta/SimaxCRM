using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadLanguageService
    {
        List<LeadLanguage> List();
        LeadLanguage ById(int id);
        void Create(LeadLanguage serviceType);
        void Update(LeadLanguage serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<LeadLanguage, bool>> predicate);
    }
}
