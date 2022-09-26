using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ISocietyService
    {
        List<Society> List();
        List<Society> ListByCityId(int cityId);
        Society ById(int id);
        void Create(Society serviceType);
        void Update(Society serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<Society, bool>> predicate);
    }
}
