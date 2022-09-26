using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IAttachmentProductMappingService
    {
        List<AttachmentProductMapping> List();
        AttachmentProductMapping ById(int id);
        void Create(AttachmentProductMapping serviceType, bool hasTid = true);
        void Update(AttachmentProductMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<AttachmentProductMapping, bool>> predicate);
        List<AttachmentProductMapping> ListByProductId(int productId);
    }
}
