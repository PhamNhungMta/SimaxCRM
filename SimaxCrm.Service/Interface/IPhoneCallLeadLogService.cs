using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IPhoneCallLeadLogService
    {
        List<PhoneCallLeadLog> List();
        PhoneCallLeadLog ById(int id);
        void Create(PhoneCallLeadLog serviceType);
        void Update(PhoneCallLeadLog serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<PhoneCallLeadLog, bool>> predicate);
        List<PhoneCallLeadLog> GetByPhoneDates(List<string> dates);
    }
}
