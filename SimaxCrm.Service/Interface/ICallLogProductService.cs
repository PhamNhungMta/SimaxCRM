using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ICallLogProductService
    {
        List<CallLogProduct> List();
        CallLogProduct ById(int id);
        void Create(CallLogProduct serviceType);
        void Update(CallLogProduct serviceType);
        List<CallLogProduct> ByInvoiceId(int invoiceId);
        List<CallLogProduct> GetOldActiveReminder(string userId);
        List<CallLogProduct> GetFollowUpByLeadIds(List<int> productIds);
        List<CallLogProduct> GetAllOldActiveReminder();
    }
}
