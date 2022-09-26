using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadAutoAssignLogService
    {
        List<LeadAutoAssignLog> List();
        LeadAutoAssignLog ById(int id);
        void Create(LeadAutoAssignLog serviceType);
        void Update(LeadAutoAssignLog serviceType);
        void Delete(int id);
        List<LeadAutoAssignLog> ListByDate(DateTime date, int tid);
    }
}
