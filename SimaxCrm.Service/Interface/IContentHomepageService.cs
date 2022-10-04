using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IContentHomepageService
    {
        ContentHomepage ById(int Id);
        ContentHomepage GetHomepageByAgentId(string AgentId);
        ContentHomepage GetHomepageByCompanyId(string CompanyId);
        ContentHomepage GetHomepageByBranchId(string BranchId);
        ContentHomepage GetHomepageByCompanyName(string CompanyName);
        ContentHomepage GetHomepageByBranchName(string BranchName);
        void Create(ContentHomepage homepage);
        void Update(ContentHomepage homepage);
    }
}