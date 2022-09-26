using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public void Create(City city)
        {
            _cityRepository.Insert(city);
        }

        public void Delete(int id)
        {
            var obj = _cityRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _cityRepository.Delete(obj);
        }

        public void Update(City city)
        {
            _cityRepository.UpdateEntity(city);
        }

        public List<City> List()
        {
            return _cityRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public City ById(int id)
        {
            return _cityRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<City, bool>> predicate)
        {
            return _cityRepository.SearchFor().Any(predicate);
        }
    }
}
