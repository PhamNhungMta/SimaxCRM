using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class CallLogProductService : ICallLogProductService
    {
        private readonly ICallLogProductRepository _callLogProductRepository;
        public CallLogProductService(ICallLogProductRepository callLogProductRepository)
        {
            _callLogProductRepository = callLogProductRepository;
        }

        public void Create(CallLogProduct callLogProduct)
        {
            _callLogProductRepository.Insert(callLogProduct);
        }

        public void Update(CallLogProduct callLogProduct)
        {
            _callLogProductRepository.UpdateEntity(callLogProduct);
        }

        public List<CallLogProduct> List()
        {
            return _callLogProductRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public CallLogProduct ById(int id)
        {
            return _callLogProductRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<CallLogProduct> ByInvoiceId(int invoiceId)
        {
            return _callLogProductRepository.SearchFor(x => x.InvoiceId == invoiceId).ToList();
        }

        public List<CallLogProduct> GetOldActiveReminder(string userId)
        {
            var dated = DateTime.Now.AddMinutes(10);
            return _callLogProductRepository.SearchFor(x => x.UserId == userId && x.AlertDate != null && x.AlertDate <= dated, "Product").ToList();
        }

        public List<CallLogProduct> GetFollowUpByLeadIds(List<int> productIds)
        {
            return _callLogProductRepository.SearchFor(x => productIds.Contains(x.ProductId) && x.AlertDate != null, "Product").ToList();
        }

        public List<CallLogProduct> GetAllOldActiveReminder()
        {
            var dated = DateTime.Now.AddMinutes(10);
            return _callLogProductRepository.SearchFor(x => x.AlertDate != null && x.AlertDate <= dated && x.AlertStatusFcm == Model.Enum.AlertStatusType.Pending, hasTid: false).ToList();
        }
    }
}
