using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IPhoneCallProductLogService
    {
        List<PhoneCallProductLog> List();
        PhoneCallProductLog ById(int id);
        void Create(PhoneCallProductLog serviceType);
        void Update(PhoneCallProductLog serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<PhoneCallProductLog, bool>> predicate);
        List<PhoneCallProductLog> GetByPhoneDates(List<string> dates);
    }
}
