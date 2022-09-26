using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class SeoService : ISeoService
    {
        private readonly ISeoRepository _seoRepository;
        public SeoService(ISeoRepository seoRepository)
        {
            _seoRepository = seoRepository;
        }

        public void Create(Seo seo, bool hasTid = true)
        {
            _seoRepository.Insert(seo, hasTid: false);
        }

        public void Delete(int id)
        {
            var obj = _seoRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _seoRepository.Delete(obj);
        }

        public void Update(Seo seo)
        {
            _seoRepository.UpdateEntity(seo, hasTid: false);
        }

        public List<Seo> List()
        {
            return _seoRepository.SearchFor(null, hasTid: false).OrderByDescending(x => x.Id).ToList();
        }

        public Seo ById(int id)
        {
            return _seoRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }


    }
}
