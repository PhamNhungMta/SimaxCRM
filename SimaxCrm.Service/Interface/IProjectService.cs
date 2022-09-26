using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using System;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IProjectService
    {
        List<Project> List();
        Project ById(int id, bool hasTracking = true);
        void Create(Project serviceType);
        void Update(Project serviceType);
        void Delete(int id);
        List<Project> GetMatchingByLead(Lead lead, int tid);
        List<Project> ByLeadStatusAndUserId(string status, List<string> userIds, ProjectsViewFilterModel projectsViewFilterModel);
        ListResponseModel<Project> ListByFilter(ProjectMainFilterModel model);
        List<Project> GetFollowUpByProjectIds(List<int> projectIds);
        List<Project> GetFeaturedProject(int cityId);
        List<Project> ListByContact(List<string> contacts);
        List<KeyValueResponse> ProjectGroupByTid();
        List<KeyValueResponse> ProjectGroupByUid(List<string> uids);
        List<Project> GetRelatedProjects(Project project);
    }
}
