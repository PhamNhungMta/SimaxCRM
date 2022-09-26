using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ISubCategoryService
    {
        List<SubCategory> List();
        List<SubCategory> ListByCategoryId(int categoryId);
        SubCategory ById(int id);
        void Create(SubCategory serviceType);
        void Update(SubCategory serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<SubCategory, bool>> predicate);
    }
}
