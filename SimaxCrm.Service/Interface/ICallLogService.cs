using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ICallLogService
    {
        List<CallLog> List();
        CallLog ById(int id);
        void Create(CallLog serviceType, bool hasTid = true);
        void Update(CallLog serviceType);
        List<CallLog> ByInvoiceId(int invoiceId);
        List<CallLog> GetOldActiveReminder(string userId);
        List<CallLog> GetFollowUpByLeadIds(List<int> leadIds);
        List<CallLog> GetAllOldActiveReminder();
        void CreateWithoutTid(CallLog calLog);
    }
}
