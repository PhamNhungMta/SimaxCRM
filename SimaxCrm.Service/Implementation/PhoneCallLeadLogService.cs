using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class PhoneCallLeadLogService : IPhoneCallLeadLogService
    {
        private readonly IPhoneCallLeadLogRepository _phoneCallLeadLogRepository;
        public PhoneCallLeadLogService(IPhoneCallLeadLogRepository phoneCallLeadLogRepository)
        {
            _phoneCallLeadLogRepository = phoneCallLeadLogRepository;
        }

        public void Create(PhoneCallLeadLog phoneCallLeadLog)
        {
            _phoneCallLeadLogRepository.Insert(phoneCallLeadLog);
        }

        public void Delete(int id)
        {
            var obj = _phoneCallLeadLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _phoneCallLeadLogRepository.Delete(obj);
        }

        public void Update(PhoneCallLeadLog phoneCallLeadLog)
        {
            _phoneCallLeadLogRepository.UpdateEntity(phoneCallLeadLog);
        }

        public List<PhoneCallLeadLog> List()
        {
            return _phoneCallLeadLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public PhoneCallLeadLog ById(int id)
        {
            return _phoneCallLeadLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<PhoneCallLeadLog, bool>> predicate)
        {
            return _phoneCallLeadLogRepository.SearchFor().Any(predicate);
        }

        public List<PhoneCallLeadLog> GetByPhoneDates(List<string> dates)
        {
            return _phoneCallLeadLogRepository.SearchFor(m => dates.Contains(m.Date)).ToList();
        }
    }
}
