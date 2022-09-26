using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ICityService
    {
        List<City> List();       

        City ById(int id);
        void Create(City serviceType);
        void Update(City serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<City, bool>> predicate);
    }
}
