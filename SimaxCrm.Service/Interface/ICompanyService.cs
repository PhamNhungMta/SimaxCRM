using System.Threading.Tasks;
using System.Collections.Generic;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;

namespace SimaxCrm.Service.Interface
{
    public interface ICompanyService
    {
        List<Company> List();
        Company ById(string Id);
        Company ByName(string Name);
        Company ByIdAndName(string Id, string Name);
        void Create(Company company);
        void Update(Company company);
        Task<List<Dossier>> GetDossierList ();
    }
}