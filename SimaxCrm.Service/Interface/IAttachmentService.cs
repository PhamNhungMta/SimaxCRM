using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IAttachmentService
    {
        List<Attachment> List();
        Attachment ById(int id);
        void Create(Attachment serviceType, bool hasTid = true);
        void Update(Attachment serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<Attachment, bool>> predicate);
        List<Attachment> ListByFolderCateTempId(int? uploadCategoryId, string tempId);
        List<Attachment> ListByTempId(string tempId);
    }
}
