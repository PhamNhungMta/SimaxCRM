using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public void Create(Location location)
        {
            _locationRepository.Insert(location);
        }

        public void Delete(int id)
        {
            var obj = _locationRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _locationRepository.Delete(obj);
        }

        public void Update(Location location)
        {
            _locationRepository.UpdateEntity(location);
        }

        public List<Location> List()
        {
            return _locationRepository.SearchFor(null).OrderByDescending(x => x.Id).ToList();
        }
        public List<Location> ListByCityId(int cityId)
        {
            return _locationRepository.SearchFor(x => x.CityId == cityId).OrderByDescending(x => x.Id).ToList();
        }

        public Location ById(int id)
        {
            return _locationRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Location, bool>> predicate)
        {
            return _locationRepository.SearchFor().Any(predicate);
        }
    }
}
