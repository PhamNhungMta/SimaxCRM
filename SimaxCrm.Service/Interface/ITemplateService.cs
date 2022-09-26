using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface ITemplateService
    {
        List<Template> List();
        Template ById(int id);
        void Create(Template serviceType);
        void Update(Template serviceType);
        void Delete(int id);
        List<Template> ByType(TemplateType type);
    }
}
