using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class LeadAutoAssignLogService : ILeadAutoAssignLogService
    {
        private readonly ILeadAutoAssignLogRepository _leadAutoAssignLogRepository;
        public LeadAutoAssignLogService(ILeadAutoAssignLogRepository leadAutoAssignLogRepository)
        {
            _leadAutoAssignLogRepository = leadAutoAssignLogRepository;
        }

        public void Create(LeadAutoAssignLog leadAutoAssign)
        {
            _leadAutoAssignLogRepository.Insert(leadAutoAssign);
        }

        public void Delete(int id)
        {
            var obj = _leadAutoAssignLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadAutoAssignLogRepository.Delete(obj);
        }

        public void Update(LeadAutoAssignLog leadAutoAssign)
        {
            _leadAutoAssignLogRepository.UpdateEntity(leadAutoAssign);
        }

        public List<LeadAutoAssignLog> List()
        {
            return _leadAutoAssignLogRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public LeadAutoAssignLog ById(int id)
        {
            return _leadAutoAssignLogRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public List<LeadAutoAssignLog> ListByDate(DateTime date, int tid)
        {
            if (tid > 0)
            {
                return _leadAutoAssignLogRepository.SearchFor(x => x.CreatedDate.Date == date & x.Tid == tid, hasTid: false).ToList();
            }
            else
            {
                return _leadAutoAssignLogRepository.SearchFor(x => x.CreatedDate.Date == date).ToList();
            }
        }
    }
}
