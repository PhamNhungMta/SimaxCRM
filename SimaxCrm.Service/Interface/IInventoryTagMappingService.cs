using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IInventoryTagMappingService
    {
        List<InventoryTagMapping> List();
        InventoryTagMapping ById(int id);
        void Create(InventoryTagMapping serviceType);
        void Update(InventoryTagMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<InventoryTagMapping, bool>> predicate);
        List<InventoryTagMapping> ByProductId(int productId);
    }
}
