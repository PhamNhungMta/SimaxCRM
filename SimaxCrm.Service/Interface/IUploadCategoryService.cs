using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IUploadCategoryService
    {
        List<UploadCategory> List(bool hasTid = true);
        UploadCategory ById(int id);
        void Create(UploadCategory serviceType, bool hasTid = true);
        void Update(UploadCategory serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<UploadCategory, bool>> predicate);
    }
}
