using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class SocietyService : ISocietyService
    {
        private readonly ISocietyRepository _societyRepository;
        public SocietyService(ISocietyRepository societyRepository)
        {
            _societyRepository = societyRepository;
        }

        public void Create(Society society)
        {
            _societyRepository.Insert(society);
        }

        public void Delete(int id)
        {
            var obj = _societyRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _societyRepository.Delete(obj);
        }

        public void Update(Society society)
        {
            _societyRepository.UpdateEntity(society);
        }

        public List<Society> List()
        {
            return _societyRepository.SearchFor(null).OrderByDescending(x => x.Id).ToList();
        }
        public List<Society> ListByCityId(int cityId)
        {
            return _societyRepository.SearchFor(x => x.CityId == cityId).OrderByDescending(x => x.Id).ToList();
        }
        public Society ById(int id)
        {
            return _societyRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Society, bool>> predicate)
        {
            return _societyRepository.SearchFor().Any(predicate);
        }
    }
}
