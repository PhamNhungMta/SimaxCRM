using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILocationService
    {
        List<Location> List();
        List<Location> ListByCityId(int cityId);
        Location ById(int id);
        void Create(Location serviceType);
        void Update(Location serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<Location, bool>> predicate);
    }
}
