using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public void Create(Attachment attachment, bool hasTid = true)
        {
            _attachmentRepository.Insert(attachment, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _attachmentRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _attachmentRepository.Delete(obj);
        }

        public void Update(Attachment attachment)
        {
            _attachmentRepository.UpdateEntity(attachment);
        }

        public List<Attachment> List()
        {
            return _attachmentRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Attachment ById(int id)
        {
            return _attachmentRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Attachment, bool>> predicate)
        {
            return _attachmentRepository.SearchFor().Any(predicate);
        }

        public List<Attachment> ListByFolderCateTempId(int? uploadCategoryId, string tempId)
        {
            return _attachmentRepository.SearchFor(x => x.UploadCategoryId == uploadCategoryId && x.TempId == tempId).ToList();
        }

        public List<Attachment> ListByTempId(string tempId)
        {
            return _attachmentRepository.SearchFor(x => x.TempId == tempId).ToList();
        }
    }
}
