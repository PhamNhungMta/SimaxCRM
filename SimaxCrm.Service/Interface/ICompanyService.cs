using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ICompanyService
    {
        Company ById(string Id);
        Company ByName(string Name);
        Company ByIdAndName(string Id, string Name);
        void Create(Company company);
        void Update(Company company);
    }
}