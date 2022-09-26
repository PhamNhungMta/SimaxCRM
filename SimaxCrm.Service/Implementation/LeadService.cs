using Microsoft.AspNetCore.Identity;
using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class LeadService : ILeadService
    {
        private readonly ITempLeadService _tempLeadService;
        private readonly ILeadRepository _leadRepository;
        private readonly ILeadProductMappingService _leadProductMappingService;
        private readonly ILeadTagMappingService _leadTagMappingService;
        private readonly ILeadAutoAssignLogService _leadAutoAssignLogService;
        private readonly ICallLogService _callLogService;

        public LeadService(ILeadRepository leadRepository,
            ILeadProductMappingService leadProductMappingService,
            ILeadTagMappingService leadTagMappingService,
            IHelperService helperService,
            ITempLeadService tempLeadService,
            ILeadAutoAssignLogService leadAutoAssignLogService,
            ISystemSetupService systemSetupService,
            ICallLogService callLogService
            )
        {
            _tempLeadService = tempLeadService;
            _leadRepository = leadRepository;
            _leadProductMappingService = leadProductMappingService;
            _leadTagMappingService = leadTagMappingService;
            _leadAutoAssignLogService = leadAutoAssignLogService;
            _callLogService = callLogService;
        }

        public void Create(Lead lead, bool hasTid = true)
        {
            _leadRepository.Insert(lead, hasTid: hasTid);
        }

        public void CreateWithoutTid(Lead lead)
        {
            _leadRepository.Insert(lead, hasTid: false);
        }

        public void Delete(int id, string uid)
        {
            var obj = _leadRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            obj.LeadStatus = LeadStatusType.Deleted.ToString();
            obj.DeletedById = uid;
            obj.DeletedDate = DateTime.Now;
            _leadRepository.UpdateEntity(obj);
        }

        public void DeleteDone(int id)
        {
            var obj = _leadRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _leadRepository.Delete(obj);
        }

        public void Update(Lead lead, bool hasTid = true)
        {
            _leadRepository.UpdateEntity(lead, hasTid: hasTid);
        }

        public List<Lead> List()
        {
            return _leadRepository.SearchFor(null, "LeadSource,User,LeadTagMapping,LeadTagMapping.LeadTag").OrderByDescending(x => x.Id).ToList();
        }

        public Lead ById(int id, bool hasTid = true)
        {
            return _leadRepository.SearchFor(x => x.Id == id, "User,LeadTagMapping,LeadProductMapping,CallLog,CallLog.User,PhoneCallLeadLog,PhoneCallLeadLog.User", hasTid: hasTid).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Lead, bool>> predicate)
        {
            return _leadRepository.SearchFor().Any(predicate);
        }

        public List<Lead> ByUserIds(List<string> userIds, DateTime? startDate, DateTime? endDate, string leadStatus)
        {

            var query = _leadRepository.SearchFor(m => m.LeadStatus != LeadStatusType.Deleted.ToString(), "LeadSource,User,LeadTagMapping,LeadTagMapping.LeadTag");
            if (userIds != null)
            {
                query = query.Where(m => userIds.Contains(m.UserId));
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

        public List<Lead> AllLeads()
        {
            return _leadRepository.SearchFor(null).ToList();
        }

        public List<Lead> ByLeadStatusAndUserId(string leadStatus, List<string> userIds, DateTime? startDate, DateTime? endDate)
        {
            if (leadStatus.ToLower() == "Deleted".ToLower())
            {
                var query = _leadRepository.SearchFor(x => x.LeadStatus == leadStatus, "LeadSource,User,LeadTagMapping,LeadTagMapping.LeadTag,DeletedBy", hasTid: false);
                //if (userIds != null)
                //{
                //    query = query.Where(m => userIds.Contains(m.UserId));
                //}
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
            else
            {
                var query = _leadRepository.SearchFor(x => x.LeadStatus == leadStatus, "LeadSource,User,LeadTagMapping,LeadTagMapping.LeadTag");
                if (userIds != null)
                {
                    query = query.Where(m => userIds.Contains(m.UserId));
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
        }

        public List<Lead> ByIds(int[] leadIds, bool hasTid = false)
        {
            return _leadRepository.SearchFor(m => leadIds.Contains(m.Id), hasTid: hasTid).ToList();
        }

        public void CreateRange(List<Lead> list)
        {
            _leadRepository.InsertRange(list);
        }

        public BaseResponse<string> CreateLead(Lead obj, string userId)
        {
            if (obj.BudgetMax < obj.BudgetMin)
            {
                return new BaseResponse<string> { Success = false, ModelKey = "BudgetMax", Response = "Budget max should be greater then budget min" };
            }

            bool isAutoAssign = false;

            if (this.IsAny(m => m.PhoneNumber == obj.PhoneNumber))
            {
                return new BaseResponse<string> { Success = false, ModelKey = "PhoneNumber", Response = "Phone number already exists" };
            }

            if (!string.IsNullOrEmpty(obj.Email))
            {
                if (this.IsAny(m => m.Email == obj.Email))
                {
                    return new BaseResponse<string> { Success = false, ModelKey = "Email", Response = "Email already exists" };
                }
            }

            //if (obj.UserId == "Auto")
            //{
            //    isAutoAssign = true;
            //    var assignToUserId = _helperService.AssignAgentSourceAndRankingWise(obj.LeadSourceId);
            //    obj.UserId = string.IsNullOrEmpty(assignToUserId) ? null : assignToUserId;
            //}

            obj.CreatedDate = DateTime.Now;
            obj.CreatedBy = userId;
            obj.AssignedDate = DateTime.Now;
            obj.LeadStatus = LeadStatusType.NewLead.ToString();
            this.Create(obj);

            //delete temp lead
            if (obj.TempLeadId > 0)
            {
                _tempLeadService.Delete(obj.TempLeadId);
            }

            //Notification
            var calLog = new CallLog()
            {
                AlertDate = DateTime.Now,
                AlertStatus = AlertStatusType.Pending,
                AlertStatusFcm = AlertStatusType.Pending,
                CreatedDate = DateTime.Now,
                EndTime = DateTime.Now.TimeOfDay,
                Id = 0,
                LeadId = obj.Id,
                UserId = obj.UserId ?? userId,
                Remarks = "New Lead",
                Status = "Lead",
                Message = "New Lead Created",
                StartTime = DateTime.Now.TimeOfDay,
            };
            _callLogService.Create(calLog);
            //End Notification

            if (isAutoAssign)
            {
                var leadAutoAssignLog = new LeadAutoAssignLog()
                {
                    Id = 0,
                    LeadId = obj.Id,
                    LeadSourceId = obj.LeadSourceId,
                    UserId = obj.UserId,
                    CreatedDate = DateTime.Now
                };
                _leadAutoAssignLogService.Create(leadAutoAssignLog);
            }

            if (!string.IsNullOrEmpty(obj.LeadTags))
            {
                foreach (var item in obj.LeadTags.Split(','))
                {
                    var leadTagMapping = new LeadTagMapping()
                    {
                        Id = 0,
                        LeadId = obj.Id,
                        LeadTagId = int.Parse(item),
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    _leadTagMappingService.Create(leadTagMapping);
                }
            }

            if (!string.IsNullOrEmpty(obj.ProductIds))
            {
                foreach (var item in obj.ProductIds.Split(','))
                {
                    var leadProductMapping = new LeadProductMapping()
                    {
                        Id = 0,
                        LeadId = obj.Id,
                        ProductId = int.Parse(item),
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    _leadProductMappingService.Create(leadProductMapping);
                }
            }

            //if (!string.IsNullOrEmpty(obj.Locations))
            //{
            //    foreach (var item in obj.Locations.Split(','))
            //    {
            //        var leadLocationMapping = new LeadLocationMapping()
            //        {
            //            Id = 0,
            //            LeadId = obj.Id,
            //            LocationId = int.Parse(item),
            //            CreatedDate = DateTime.Now,
            //            Status = true,
            //        };
            //        _leadLocationMappingService.Create(leadLocationMapping);
            //    }
            //}

            //if (!string.IsNullOrEmpty(obj.Societys))
            //{
            //    foreach (var item in obj.Societys.Split(','))
            //    {
            //        var leadSocietyMapping = new LeadSocietyMapping()
            //        {
            //            Id = 0,
            //            LeadId = obj.Id,
            //            SocietyId = int.Parse(item),
            //            CreatedDate = DateTime.Now,
            //            Status = true,
            //        };
            //        _leadSocietyMappingService.Create(leadSocietyMapping);
            //    }
            //}

            return new BaseResponse<string> { Success = true, ModelKey = "", Response = "Lead Saved Successfully, Lead Id: " + obj.IdStr };
        }

        public List<Lead> GetFollowUpByLeadIds(List<int> leadIds)
        {
            return _leadRepository.SearchFor(m => leadIds.Contains(m.Id) && m.LeadStatus == LeadStatusType.FollowUp.ToString(), "User,CallLog").ToList();
        }

        public List<Lead> ListByContact(List<string> contacts)
        {
            return _leadRepository.SearchFor(m => contacts.Contains(m.PhoneNumber)).ToList();
        }

        public List<Lead> ListByUserId(string id)
        {
            return _leadRepository.SearchFor(m => m.UserId == id).ToList();
        }

        public List<Lead> ListByTid(int tid)
        {
            return _leadRepository.SearchFor(m => m.Tid == tid, hasTid: false).ToList();
        }

        public List<KeyValueResponse> LeadsGroupByTid()
        {

            var query = _leadRepository.SearchFor(null, hasTid: false).AsQueryable();
            var queryData = from q in query
                            group q by q.Tid into gg
                            select new KeyValueResponse
                            {
                                Key = gg.Key,
                                Value = gg.Count()
                            };

            return queryData.ToList();
        }

        public List<Lead> ByLeadSummaryReportModel(LeadSummaryReportModel model, List<string> userIds)
        {
            var query = _leadRepository.SearchFor(m => m.UserId != null, "User,PhoneCallLeadLog,CallLog,LeadTagMapping,LeadTagMapping.LeadTag,LeadSource");
            if (userIds != null)
            {
                query = query.Where(m => userIds.Contains(m.UserId));
            }
            if (model.StartDate.HasValue)
            {
                query = query.Where(m => m.CreatedDate.Date >= model.StartDate.Value);
            }
            if (model.EndDate.HasValue)
            {
                query = query.Where(m => m.CreatedDate.Date <= model.EndDate.Value);
            }
            return query.ToList();
        }

        public List<KeyValueResponse> LeadsGroupByUid(List<string> uids)
        {
            var query = _leadRepository.SearchFor(null, hasTid: false).AsQueryable();
            var queryData = from q in query
                            group q by q.UserId into gg
                            select new KeyValueResponse
                            {
                                KeyStr = gg.Key,
                                Value = gg.Count()
                            };

            return queryData.ToList();
        }

        public List<Lead> GetByLeadIds(List<int> newOrderIds, bool hasTid = true)
        {
            return _leadRepository.SearchFor(m => newOrderIds.Contains(m.Id), "User", hasTid: hasTid).ToList();
        }
    }
}
