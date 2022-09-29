using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxShop.Service.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company ById(string Id)
        {
            return _companyRepository.SearchFor(x => x.Id == Id).FirstOrDefault();
        }

        public Company ByName(string Name)
        {
            return _companyRepository.SearchFor(x => x.Name == Name).FirstOrDefault();
        }

        public void Create(Company company)
        {
            _companyRepository.Insert(company);
        }

        public void Update(Company company)
        {
            _companyRepository.UpdateEntity(company);
        }
        
    }

}