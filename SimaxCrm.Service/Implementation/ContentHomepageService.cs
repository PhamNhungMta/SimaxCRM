using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SimaxShop.Service.Implementation
{
    public class ContentHomepageService : IContentHomepageService
    {
        private readonly IContentHomepageRepository _ContentHomepageRepository;

        public ContentHomepageService(IContentHomepageRepository ContentHomepageRepository)
        {
            _ContentHomepageRepository = ContentHomepageRepository;
        }

        public ContentHomepage GetHomepageByAgentId(string AgentId)
        {
            return _ContentHomepageRepository.SearchFor(x => x.AgentId == AgentId).FirstOrDefault();
        }

        public void Create(ContentHomepage homepage)
        {
            _ContentHomepageRepository.Insert(homepage);
        }

        public void Update(ContentHomepage homepage)
        {
            _ContentHomepageRepository.UpdateEntity(homepage);
        }
        
    }

}