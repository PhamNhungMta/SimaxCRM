using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxShop.Service.Implementation
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public Branch ById(string Id)
        {
            return _branchRepository.SearchFor(x => x.Id == Id).FirstOrDefault();
        }

        public Branch ByNameAndCompanyId(string Name, string CompanyId)
        {
            return _branchRepository.SearchFor(x => x.Name == Name && x.CompanyId == CompanyId).FirstOrDefault();
        }
        public void Create(Branch branch)
        {
            _branchRepository.Insert(branch);
        }

        public void Update(Branch branch)
        {
            _branchRepository.UpdateEntity(branch);
        }
        
    }

}