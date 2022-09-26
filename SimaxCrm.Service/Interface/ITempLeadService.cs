using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface ITempLeadService
    {
        List<TempLead> List();
        TempLead ById(int id);
        void Create(TempLead serviceType);
        void Update(TempLead serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<TempLead, bool>> predicate);
        List<TempLead> ByUserIds(List<string> userIds, DateTime? startDate, DateTime? endDate);
        List<TempLead> AllTempLeads();
        List<TempLead> ByIds(int[] tempTempLeadIds);
        void CreateRange(List<TempLead> list);
        BaseResponse<string> CreateTempLead(TempLead tempTempLead, string userId);
        List<TempLead> ListByContact(List<string> contacts);
        List<TempLead> ListByUserId(string id);
    }
}
