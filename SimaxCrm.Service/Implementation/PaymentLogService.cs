using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using SimaxCrm.Model.Entity;
using System.Linq.Expressions;
using System;

namespace SimaxCrm.Service.Implementation
{
    public class PaymentLogService : IPaymentLogService
    {
        private readonly IPaymentLogRepository _paymentLogRepository;
        public PaymentLogService(IPaymentLogRepository paymentLogRepository)
        {
            _paymentLogRepository = paymentLogRepository;
        }

        public void Create(PaymentLog paymentLog, bool hasTid = true)
        {
            _paymentLogRepository.Insert(paymentLog, hasTid: hasTid);
        }

        public void Delete(int id)
        {
            var obj = _paymentLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _paymentLogRepository.Delete(obj);
        }

        public void Update(PaymentLog paymentLog)
        {
            _paymentLogRepository.UpdateEntity(paymentLog);
        }

        public List<PaymentLog> List()
        {
            return _paymentLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public PaymentLog ById(int id)
        {
            return _paymentLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }
    }
}
