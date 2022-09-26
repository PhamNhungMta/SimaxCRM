using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class AttachmentProjectMappingService : IAttachmentProjectMappingService
    {
        private readonly IAttachmentProjectMappingRepository _attachmentProjectMappingRepository;
        public AttachmentProjectMappingService(IAttachmentProjectMappingRepository attachmentProjectMappingRepository)
        {
            _attachmentProjectMappingRepository = attachmentProjectMappingRepository;
        }

        public void Create(AttachmentProjectMapping attachmentProjectMapping, bool hasTid = true)
        {
            _attachmentProjectMappingRepository.Insert(attachmentProjectMapping, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _attachmentProjectMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _attachmentProjectMappingRepository.Delete(obj);
        }

        public void Update(AttachmentProjectMapping attachmentProjectMapping)
        {
            _attachmentProjectMappingRepository.UpdateEntity(attachmentProjectMapping);
        }

        public List<AttachmentProjectMapping> List()
        {
            return _attachmentProjectMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public AttachmentProjectMapping ById(int id)
        {
            return _attachmentProjectMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<AttachmentProjectMapping, bool>> predicate)
        {
            return _attachmentProjectMappingRepository.SearchFor().Any(predicate);
        }

        public List<AttachmentProjectMapping> ListByProjectId(int productId)
        {
            return _attachmentProjectMappingRepository.SearchFor(x => x.ProjectId == productId, "Attachment").ToList();
        }
    }
}
