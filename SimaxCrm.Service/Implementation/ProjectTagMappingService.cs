using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class ProjectTagMappingService : IProjectTagMappingService
    {
        private readonly IProjectTagMappingRepository _projectTagMappingRepository;
        public ProjectTagMappingService(IProjectTagMappingRepository projectTagMappingRepository)
        {
            _projectTagMappingRepository = projectTagMappingRepository;
        }

        public void Create(ProjectTagMapping projectTagMapping)
        {
            _projectTagMappingRepository.Insert(projectTagMapping);
        }

        public void Delete(int id)
        {
            var obj = _projectTagMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _projectTagMappingRepository.Delete(obj);
        }

        public void Update(ProjectTagMapping projectTagMapping)
        {
            _projectTagMappingRepository.UpdateEntity(projectTagMapping);
        }

        public List<ProjectTagMapping> List()
        {
            return _projectTagMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public ProjectTagMapping ById(int id)
        {
            return _projectTagMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<ProjectTagMapping, bool>> predicate)
        {
            return _projectTagMappingRepository.SearchFor().Any(predicate);
        }

        public List<ProjectTagMapping> ByProjectId(int projectId)
        {
            return _projectTagMappingRepository.SearchFor(x => x.ProjectId == projectId).ToList();
        }
    }
}
