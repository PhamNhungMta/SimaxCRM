using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class MessageDetailService : IMessageDetailService
    {
        private readonly IMessageDetailRepository _messageDetailRepository;
        public MessageDetailService(IMessageDetailRepository messageDetailRepository)
        {
            _messageDetailRepository = messageDetailRepository;
        }

        public void Create(MessageDetail messageDetail, bool hasTid = true)
        {
            _messageDetailRepository.Insert(messageDetail, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _messageDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _messageDetailRepository.Delete(obj);
        }

        public void Update(MessageDetail messageDetail)
        {
            _messageDetailRepository.UpdateEntity(messageDetail);
        }

        public List<MessageDetail> List()
        {
            return _messageDetailRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public MessageDetail ById(int id)
        {
            return _messageDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<MessageDetail, bool>> predicate)
        {
            return _messageDetailRepository.SearchFor().Any(predicate);
        }

        public MessageDetail ByMessageIdAndUserId(int messageId, string userId)
        {
            return _messageDetailRepository.SearchFor(x => x.MessageId == messageId && x.SentToUserId == userId).FirstOrDefault();
        }

        public List<MessageDetail> ListByUserId(string id)
        {
            return _messageDetailRepository.SearchFor(x => x.SentToUserId == id, hasTracking: false).ToList();
        }
    }
}
