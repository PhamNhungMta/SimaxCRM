using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IMessageService
    {
        List<Message> List();
        Message ById(int id);
        void Create(Message serviceType, bool hasTid = true);
        void Update(Message serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<Message, bool>> predicate);
        List<Message> GetOldActiveReminder(string v);
    }
}
