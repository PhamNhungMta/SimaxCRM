using SimaxCrm.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Interface
{
    public interface IProjectTagMappingService
    {
        List<ProjectTagMapping> List();
        ProjectTagMapping ById(int id);
        void Create(ProjectTagMapping serviceType);
        void Update(ProjectTagMapping serviceType);
        void Delete(int id);
        bool IsAny(Expression<Func<ProjectTagMapping, bool>> predicate);
        List<ProjectTagMapping> ByProjectId(int projectId);
    }
}
