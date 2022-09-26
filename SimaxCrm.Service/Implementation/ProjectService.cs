using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void Create(Project project)
        {
            _projectRepository.Insert(project);
        }

        public void Delete(int id)
        {
            var obj = _projectRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _projectRepository.Delete(obj);
        }

        public void Update(Project project)
        {
            _projectRepository.UpdateEntity(project);
        }

        public List<Project> List()
        {
            return _projectRepository.SearchFor(null, "Location,Society").OrderByDescending(x => x.Id).ToList();
        }

        public Project ById(int id, bool hasTracking = true)
        {
            return _projectRepository.SearchFor(x => x.Id == id, "ProjectTagMapping,Location,Society,AttachmentProjectMapping,AttachmentProjectMapping.UploadCategory,AttachmentProjectMapping.Attachment,UserRating,UserRating.CreatedByUser", hasTracking: hasTracking).FirstOrDefault();
        }

        public List<Project> GetMatchingByLead(Lead lead, int tid)
        {
            var query = _projectRepository.SearchFor(null, "Location,Society", hasTid: false).AsQueryable();

           

            if (lead.PropertyCategoryId > 0)
            {
                query = query.Where(m => m.PropertyCategoryId == lead.PropertyCategoryId);
            }

            if (!string.IsNullOrEmpty(lead.LeadType))
            {
                var type = lead.LeadType == "Tenant" ? "Rent" : (lead.LeadType == "Buyer" ? "Sell" : "");
                if (!string.IsNullOrEmpty(type))
                {
                    query = query.Where(m => m.Type == type);
                }
            }

          

            if (lead.BudgetMax > 0 || lead.BudgetMin > 0)
            {
                query = query.Where(m => m.MaxSaleRate >= lead.BudgetMin && m.MaxSaleRate <= lead.BudgetMax);
            }

            var data = query.ToList();

            foreach (var item in data)
            {
                if (item.Tid == tid)
                {
                    item.Sno = 1;
                }
                else if (item.Tid == 3)
                {
                    item.Sno = 2;
                }
                else
                {
                    item.Sno = 3;
                }
            }

            return data.OrderBy(m => m.Sno).Take(150).ToList();
        }

      

        public List<Project> ByLeadStatusAndUserId(string status, List<string> userIds, ProjectsViewFilterModel projectsViewFilterModel)
        {
            var query = _projectRepository.SearchFor(null, "Location,Society");

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(m => m.Status == status);
            }
            if (userIds != null && userIds.Count > 0)
            {
                query = query.Where(m => userIds.Contains(m.CreatedBy));
            }
            if (projectsViewFilterModel != null)
            {
                if (projectsViewFilterModel.StartDate.HasValue)
                {
                    query = query.Where(m => m.CreatedDate.Date >= projectsViewFilterModel.StartDate.Value);
                }
                if (projectsViewFilterModel.EndDate.HasValue)
                {
                    query = query.Where(m => m.CreatedDate.Date <= projectsViewFilterModel.EndDate.Value);
                }
                if (projectsViewFilterModel.PropertyCategoryId > 0)
                {
                    query = query.Where(m => m.PropertyCategoryId == projectsViewFilterModel.PropertyCategoryId);
                }
                if (projectsViewFilterModel.PropertySubcategoryId > 0)
                {
                    query = query.Where(m => m.PropertySubcategoryId == projectsViewFilterModel.PropertySubcategoryId);
                }
                if (!string.IsNullOrEmpty(projectsViewFilterModel.Status) && projectsViewFilterModel.Status != "AllProject")
                {
                    query = query.Where(m => m.Status == projectsViewFilterModel.Status);
                }
                if (projectsViewFilterModel.LocationId.HasValue)
                {
                    query = query.Where(m => m.LocationId == projectsViewFilterModel.LocationId);
                }
                if (projectsViewFilterModel.SocietyId.HasValue)
                {
                    query = query.Where(m => m.SocietyId == projectsViewFilterModel.SocietyId);
                }
            }
            return query.ToList();
        }

        public List<Project> GetFollowUpByProjectIds(List<int> projectIds)
        {
            return _projectRepository.SearchFor(m => projectIds.Contains(m.Id) && m.Status == ProjectStatusType.FollowUp.ToString()).ToList();
        }

        public List<Project> ListByContact(List<string> contacts)
        {
            return _projectRepository.SearchFor(m => contacts.Contains(m.OwnerPhoneNumber)).ToList();
        }

        public List<KeyValueResponse> ProjectGroupByTid()
        {
            var query = _projectRepository.SearchFor(null, hasTid: false).AsQueryable();
            var queryData = from q in query
                            group q by q.Tid into gg
                            select new KeyValueResponse
                            {
                                Key = gg.Key,
                                Value = gg.Count()
                            };

            return queryData.ToList();
        }

        public List<KeyValueResponse> ProjectGroupByUid(List<string> uids)
        {
            var query = _projectRepository.SearchFor(null, hasTid: false).AsQueryable();
            var queryData = from q in query
                            group q by q.CreatedBy into gg
                            select new KeyValueResponse
                            {
                                KeyStr = gg.Key,
                                Value = gg.Count()
                            };

            return queryData.ToList();
        }

        public ListResponseModel<Project> ListByFilter(ProjectMainFilterModel filterModel)
        {
            var responseModel = new ListResponseModel<Project>();
            var productQuery = _projectRepository.SearchFor(x => x.ActiveStatus == ItemActiveStatusType.Published, hasTid: false);
            if (!string.IsNullOrEmpty(filterModel.Keyword))
            {
                productQuery = productQuery.Where(m => m.Name.Contains(filterModel.Keyword));
            }

            if (filterModel.CityId>0)
            {
                productQuery = productQuery.Where(m => m.CityId == filterModel.CityId);
            }

            if (filterModel.PropertyCategoryId > 0)
            {
                productQuery = productQuery.Where(m => m.PropertyCategoryId == filterModel.PropertyCategoryId);
            }


            switch (filterModel.SortBy)
            {
                case Model.Enum.SortByType.Newest:
                    productQuery = productQuery.OrderByDescending(m => m.CreatedDate);
                    break;
                case Model.Enum.SortByType.Oldest:
                    productQuery = productQuery.OrderBy(m => m.CreatedDate);
                    break;
                case Model.Enum.SortByType.SortByNameAsc:
                    productQuery = productQuery.OrderBy(m => m.Name);
                    break;
                case Model.Enum.SortByType.SortByNameDesc:
                    productQuery = productQuery.OrderByDescending(m => m.Name);
                    break;
                case Model.Enum.SortByType.PriceLowToHigh:
                    productQuery = productQuery.OrderBy(m => m.Price);
                    break;
                case Model.Enum.SortByType.PriceHighToLow:
                    productQuery = productQuery.OrderByDescending(m => m.Price);
                    break;
            }

            int skip = (filterModel.CurrentPage - 1) * filterModel.Take;

            responseModel.SortBy = (int)filterModel.SortBy;
            responseModel.Take = filterModel.Take;
            responseModel.TotalItems = productQuery.Count();
            responseModel.CurrentPage = filterModel.CurrentPage;
            responseModel.TotalPages = Math.Ceiling((decimal)responseModel.TotalItems / filterModel.Take);
            responseModel.List = productQuery.Skip(skip).Take(filterModel.Take).ToList();
            return responseModel;
        }

        public List<Project> GetRelatedProjects(Project project)
        {
            var query = _projectRepository.SearchFor(m => m.ActiveStatus == ItemActiveStatusType.Published, hasTid: false).AsQueryable();
            query = query.Where(m => m.CityId == project.CityId);
            query = query.Where(m => m.PropertyCategoryId == project.PropertyCategoryId);
            query = query.Where(m => m.PropertySubcategoryId == project.PropertySubcategoryId);
            return query.OrderByDescending(m => m.CreatedDate).Take(8).ToList();
        }

        public List<Project> GetFeaturedProject(int cityId)
        {
            var query = _projectRepository.SearchFor(m => m.ActiveStatus == ItemActiveStatusType.Published, "UserRating,Location", hasTid: false).AsQueryable();
            if (cityId>0)
            {
                query = query.Where(m => m.CityId == cityId);
            }

            return query.OrderByDescending(m => m.CreatedDate).Take(8).ToList();
        }
    }
}
