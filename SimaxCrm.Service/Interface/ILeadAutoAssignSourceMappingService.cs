using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadAutoAssignSourceMappingService
    {
        List<LeadAutoAssignSourceMapping> List();
        LeadAutoAssignSourceMapping ById(int id);
        void Create(LeadAutoAssignSourceMapping serviceType);
        void Update(LeadAutoAssignSourceMapping serviceType);
        void Delete(int id);
        List<LeadAutoAssignSourceMapping> ByLeadAutoAssignId(int leadAutoAssignId);
    }
}
