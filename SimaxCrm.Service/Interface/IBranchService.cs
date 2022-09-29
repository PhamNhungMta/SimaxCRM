using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IBranchService
    {
        Branch ById(string Id);
        Branch ByNameAndCompanyId(string Name, string CompanyId);
        void Create(Branch company);
        void Update(Branch company);
    }
}