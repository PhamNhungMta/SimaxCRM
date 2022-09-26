using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class PhoneCallProductLogService : IPhoneCallProductLogService
    {
        private readonly IPhoneCallProductLogRepository _phoneCallProductLogRepository;
        public PhoneCallProductLogService(IPhoneCallProductLogRepository phoneCallProductLogRepository)
        {
            _phoneCallProductLogRepository = phoneCallProductLogRepository;
        }

        public void Create(PhoneCallProductLog phoneCallProductLog)
        {
            _phoneCallProductLogRepository.Insert(phoneCallProductLog);
        }

        public void Delete(int id)
        {
            var obj = _phoneCallProductLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _phoneCallProductLogRepository.Delete(obj);
        }

        public void Update(PhoneCallProductLog phoneCallProductLog)
        {
            _phoneCallProductLogRepository.UpdateEntity(phoneCallProductLog);
        }

        public List<PhoneCallProductLog> List()
        {
            return _phoneCallProductLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public PhoneCallProductLog ById(int id)
        {
            return _phoneCallProductLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<PhoneCallProductLog, bool>> predicate)
        {
            return _phoneCallProductLogRepository.SearchFor().Any(predicate);
        }

        public List<PhoneCallProductLog> GetByPhoneDates(List<string> dates)
        {
            return _phoneCallProductLogRepository.SearchFor(m => dates.Contains(m.Date)).ToList();
        }
    }
}
