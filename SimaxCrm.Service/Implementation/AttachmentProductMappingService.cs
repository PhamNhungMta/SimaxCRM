using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class AttachmentProductMappingService : IAttachmentProductMappingService
    {
        private readonly IAttachmentProductMappingRepository _attachmentProductMappingRepository;
        public AttachmentProductMappingService(IAttachmentProductMappingRepository attachmentProductMappingRepository)
        {
            _attachmentProductMappingRepository = attachmentProductMappingRepository;
        }

        public void Create(AttachmentProductMapping attachmentProductMapping, bool hasTid = true)
        {
            _attachmentProductMappingRepository.Insert(attachmentProductMapping, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _attachmentProductMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _attachmentProductMappingRepository.Delete(obj);
        }

        public void Update(AttachmentProductMapping attachmentProductMapping)
        {
            _attachmentProductMappingRepository.UpdateEntity(attachmentProductMapping);
        }

        public List<AttachmentProductMapping> List()
        {
            return _attachmentProductMappingRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public AttachmentProductMapping ById(int id)
        {
            return _attachmentProductMappingRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<AttachmentProductMapping, bool>> predicate)
        {
            return _attachmentProductMappingRepository.SearchFor().Any(predicate);
        }

        public List<AttachmentProductMapping> ListByProductId(int productId)
        {
            return _attachmentProductMappingRepository.SearchFor(x => x.ProductId == productId, "Attachment").ToList();
        }
    }
}
