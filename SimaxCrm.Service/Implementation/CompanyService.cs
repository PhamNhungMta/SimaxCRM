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

        public List<Company> List()
        {
            return _companyRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Company ById(string Id)
        {
            return _companyRepository.SearchFor(x => x.Id == Id, "Branches").FirstOrDefault();
        }

        public Company ByName(string Name)
        {
            return _companyRepository.SearchFor(x => x.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public Company ByIdAndName(string Id, string Name)
        {
            return _companyRepository.SearchFor(x => x.Id == Id && x.Name.ToLower() == Name.ToLower()).FirstOrDefault();
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