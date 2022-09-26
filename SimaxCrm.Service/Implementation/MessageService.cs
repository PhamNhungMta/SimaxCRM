using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public void Create(Message message, bool hasTid = true)
        {
            _messageRepository.Insert(message, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _messageRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _messageRepository.Delete(obj);
        }

        public void Update(Message message)
        {
            _messageRepository.UpdateEntity(message);
        }

        public List<Message> List()
        {
            return _messageRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Message ById(int id)
        {
            return _messageRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Message, bool>> predicate)
        {
            return _messageRepository.SearchFor().Any(predicate);
        }

        public List<Message> GetOldActiveReminder(string userId)
        {
            AlertStatusType[] validStatus = { AlertStatusType.Pending, AlertStatusType.Shown };
            return _messageRepository.SearchFor(x => x.MessageDetail.Any(m => m.SentToUserId == userId && validStatus.Contains(m.AlertStatus)), "CreatedBy,MessageDetail", hasTid: false).ToList();
        }
    }
}
