using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IMessageDetailService
    {
        List<MessageDetail> List();
        MessageDetail ById(int id);
        void Create(MessageDetail serviceType, bool hasTid = true);
        void Update(MessageDetail serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<MessageDetail, bool>> predicate);
        MessageDetail ByMessageIdAndUserId(int messageId, string userId);
        List<MessageDetail> ListByUserId(string id);
    }
}
