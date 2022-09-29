using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IContentHomepageService
    {
        ContentHomepage GetHomepageByAgentId(string AgentId);
        ContentHomepage GetHomepageByCompanyId(string CompanyId);
        ContentHomepage GetHomepageByBranchId(string BranchId);
        void Create(ContentHomepage homepage);
        void Update(ContentHomepage homepage);
    }
}