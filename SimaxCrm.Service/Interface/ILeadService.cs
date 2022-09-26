using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadService
    {
        List<Lead> List();
        Lead ById(int id, bool hasTid = true);
        void Create(Lead serviceType, bool hasTid = true);
        void CreateWithoutTid(Lead lead);
        void Update(Lead serviceType, bool hasTid = true);
        void Delete(int id, string uid);
        void DeleteDone(int id);
        bool IsAny(Expression<Func<Lead, bool>> predicate);
        List<Lead> ByUserIds(List<string> userIds, DateTime? startDate, DateTime? endDate, string leadStatus);
        List<Lead> AllLeads();
        List<Lead> ByLeadStatusAndUserId(string leadStatus, List<string> userIds, DateTime? startDate, DateTime? endDate);
        List<Lead> ByIds(int[] leadIds, bool hasTid = true);
        void CreateRange(List<Lead> list);
        BaseResponse<string> CreateLead(Lead lead, string userId);
        List<Lead> GetFollowUpByLeadIds(List<int> leadIds);
        List<Lead> ListByContact(List<string> contacts);
        List<Lead> ListByUserId(string id);
        List<Lead> ListByTid(int tid);
        List<KeyValueResponse> LeadsGroupByTid();
        List<Lead> ByLeadSummaryReportModel(LeadSummaryReportModel model, List<string> userId);
        List<KeyValueResponse> LeadsGroupByUid(List<string> uids);
        List<Lead> GetByLeadIds(List<int> newOrderIds, bool hasTid = true);
    }
}
