using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;
        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public void Create(Template template)
        {
            _templateRepository.Insert(template);
        }

        public void Delete(int id)
        {
            var obj = _templateRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _templateRepository.Delete(obj);
        }

        public void Update(Template template)
        {
            _templateRepository.UpdateEntity(template);
        }

        public List<Template> List()
        {
            return _templateRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Template ById(int id)
        {
            return _templateRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<Template> ByType(TemplateType type)
        {
            return _templateRepository.SearchFor(x => x.Type == type).ToList();
        }
    }
}
