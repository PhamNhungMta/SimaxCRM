using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IInventoryTagService
    {
        List<InventoryTag> List();
        InventoryTag ById(int id);
        void Create(InventoryTag serviceType, bool hasTid = true);
        void Update(InventoryTag serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<InventoryTag, bool>> predicate);
    }
}
