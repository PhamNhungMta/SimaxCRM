using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ILeadRemarksService
    {
        List<LeadRemarks> List();
        LeadRemarks ById(int id);
        void Create(LeadRemarks serviceType, bool hasTid = true);
        void Update(LeadRemarks serviceType);
        void Delete(int id);
        List<LeadRemarks> ByStatus(string status);
    }
}
