using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ICategoryService
    {
        List<Category> List();
        Category ById(int id);
        void Create(Category serviceType);
        void Update(Category serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<Category, bool>> predicate);
    }
}
