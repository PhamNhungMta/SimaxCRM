using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ISeoService
    {
        List<Seo> List();
        Seo ById(int id);
        void Create(Seo serviceType, bool hasTid = true);
        void Update(Seo serviceType);
        void Delete(int id);
       

    }
}
