using Microsoft.AspNetCore.Identity;
using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class TempLeadService : ITempLeadService
    {
        private readonly ITempLeadRepository _tempLeadRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHelperService _helperService;

        public TempLeadService(ITempLeadRepository tempLeadRepository,
            UserManager<ApplicationUser> userManager,
            IHelperService helperService
            )
        {
            _tempLeadRepository = tempLeadRepository;
            _helperService = helperService;
            _userManager = userManager;
        }

        public void Create(TempLead tempLead)
        {
            _tempLeadRepository.Insert(tempLead);
        }

        public void Delete(int id)
        {
            var obj = _tempLeadRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _tempLeadRepository.Delete(obj);
        }

        public void Update(TempLead tempLead)
        {
            _tempLeadRepository.UpdateEntity(tempLead);
        }

        public List<TempLead> List()
        {
            return _tempLeadRepository.SearchFor().ToList();
        }

        public TempLead ById(int id)
        {
            return _tempLeadRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<TempLead, bool>> predicate)
        {
            return _tempLeadRepository.SearchFor().Any(predicate);
        }

        public List<TempLead> ByUserIds(List<string> userIds, DateTime? startDate, DateTime? endDate)
        {
            var query = _tempLeadRepository.SearchFor(null, "TempLeadSource,User,TempLeadTagMapping,TempLeadTagMapping.TempLeadTag,TempLeadLocationMapping,TempLeadSocietyMapping");
            if (userIds != null)
            {
                query = query.Where(m => userIds.Contains(m.CreatedBy));
            }
            if (startDate.HasValue)
            {
                query = query.Where(m => m.CreatedDate.Date >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(m => m.CreatedDate.Date <= endDate.Value);
            }
            return query.ToList();
        }

        public List<TempLead> AllTempLeads()
        {
            return _tempLeadRepository.SearchFor(null).ToList();
        }

        public List<TempLead> ByIds(int[] tempLeadIds)
        {
            return _tempLeadRepository.SearchFor(m => tempLeadIds.Contains(m.Id)).ToList();
        }

        public void CreateRange(List<TempLead> list)
        {
            _tempLeadRepository.InsertRange(list);
        }

        public BaseResponse<string> CreateTempLead(TempLead obj, string userId)
        {

            obj.CreatedDate = DateTime.Now;
            obj.CreatedBy = userId;
            this.Create(obj);

            return new BaseResponse<string> { Success = true, ModelKey = "", Response = "TempLead Saved Successfully, TempLead Id: " + obj.Id };
        }

        public List<TempLead> ListByContact(List<string> contacts)
        {
            return _tempLeadRepository.SearchFor(m => contacts.Contains(m.PhoneNumber)).ToList();
        }

        public List<TempLead> ListByUserId(string id)
        {
            return _tempLeadRepository.SearchFor(m => m.CreatedBy == id).ToList();
        }

    
    }
}
