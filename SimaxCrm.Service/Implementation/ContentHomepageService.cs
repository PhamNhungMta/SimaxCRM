using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxShop.Service.Implementation
{
    public class ContentHomepageService : IContentHomepageService
    {
        private readonly IContentHomepageRepository _contentHomepageRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IBranchRepository _branchRepository;

        public ContentHomepageService(IContentHomepageRepository contentHomepageRepository,
            ICompanyRepository companyRepository,
            IBranchRepository branchRepository)
        {
            _contentHomepageRepository = contentHomepageRepository;
            _companyRepository = companyRepository;
            _branchRepository = branchRepository;
        }

        public ContentHomepage GetHomepageByAgentId(string AgentId)
        {
            return _contentHomepageRepository.SearchFor(x => x.AgentId == AgentId).FirstOrDefault();
        }

        public ContentHomepage GetHomepageByCompanyId(string CompanyId)
        {
            return _contentHomepageRepository.SearchFor(x => x.CompanyId == CompanyId).FirstOrDefault();
        }

        public ContentHomepage GetHomepageByCompanyName(string Name)
        {
            var company = _companyRepository.SearchFor(x => x.Name == Name).FirstOrDefault();
            return _contentHomepageRepository.SearchFor(x => x.CompanyId == company.Id).FirstOrDefault();
        }

        public ContentHomepage GetHomepageByBranchId(string BranchId)
        {
            return _contentHomepageRepository.SearchFor(x => x.BranchId == BranchId).FirstOrDefault();
        }

        public ContentHomepage GetHomepageByBranchName(string Name)
        {
            var branch = _branchRepository.SearchFor(x => x.Name == Name).FirstOrDefault();
            return _contentHomepageRepository.SearchFor(x => x.BranchId == branch.Id).FirstOrDefault();
        }

        public void Create(ContentHomepage homepage)
        {
            _contentHomepageRepository.Insert(homepage);
        }

        public void Update(ContentHomepage homepage)
        {
            _contentHomepageRepository.UpdateEntity(homepage);
        }
        
    }

}