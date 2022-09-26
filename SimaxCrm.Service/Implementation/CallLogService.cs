using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class CallLogService : ICallLogService
    {
        private readonly ICallLogRepository _callLogRepository;
        public CallLogService(ICallLogRepository callLogRepository)
        {
            _callLogRepository = callLogRepository;
        }

        public void Create(CallLog callLog, bool hasTid = true)
        {
            _callLogRepository.Insert(callLog, hasTid: hasTid);
        }

        public void Update(CallLog callLog)
        {
            _callLogRepository.UpdateEntity(callLog);
        }

        public List<CallLog> List()
        {
            return _callLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public CallLog ById(int id)
        {
            return _callLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<CallLog> ByInvoiceId(int invoiceId)
        {
            return _callLogRepository.SearchFor(x => x.InvoiceId == invoiceId).ToList();
        }

        public List<CallLog> GetOldActiveReminder(string userId)
        {
            var dated = DateTime.Now.AddMinutes(10);
            return _callLogRepository.SearchFor(x => x.UserId == userId && x.AlertDate != null && x.AlertDate <= dated, "Lead").ToList();
        }

        public List<CallLog> GetFollowUpByLeadIds(List<int> leadIds)
        {
            return _callLogRepository.SearchFor(x => leadIds.Contains(x.LeadId) && x.AlertDate != null, "Lead").ToList();
        }

        public List<CallLog> GetAllOldActiveReminder()
        {
            var dated = DateTime.Now.AddMinutes(10);
            return _callLogRepository.SearchFor(x => x.AlertDate != null && x.AlertDate <= dated && x.AlertStatusFcm == Model.Enum.AlertStatusType.Pending, hasTid: false).ToList();
        }

        public void CreateWithoutTid(CallLog calLog)
        {
            _callLogRepository.Insert(calLog, hasTid: false);
        }
    }
}
