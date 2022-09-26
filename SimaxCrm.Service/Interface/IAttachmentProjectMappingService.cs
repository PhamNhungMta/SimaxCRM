using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IAttachmentProjectMappingService
    {
        List<AttachmentProjectMapping> List();
        AttachmentProjectMapping ById(int id);
        void Create(AttachmentProjectMapping serviceType, bool hasTid = true);
        void Update(AttachmentProjectMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<AttachmentProjectMapping, bool>> predicate);
        List<AttachmentProjectMapping> ListByProjectId(int productId);
    }
}
