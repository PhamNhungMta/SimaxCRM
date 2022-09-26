using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class UploadCategoryService : IUploadCategoryService
    {
        private readonly IUploadCategoryRepository _uploadCategoryRepository;
        public UploadCategoryService(IUploadCategoryRepository uploadCategoryRepository)
        {
            _uploadCategoryRepository = uploadCategoryRepository;
        }

        public void Create(UploadCategory uploadCategory, bool hasTid = true)
        {
            _uploadCategoryRepository.Insert(uploadCategory, hasTid);
        }

        public void Delete(int id)
        {
            var obj = _uploadCategoryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _uploadCategoryRepository.Delete(obj);
        }

        public void Update(UploadCategory uploadCategory)
        {
            _uploadCategoryRepository.UpdateEntity(uploadCategory);
        }

        public List<UploadCategory> List(bool hasTid = true)
        {
            return _uploadCategoryRepository.SearchFor(null, hasTid: hasTid).OrderByDescending(x => x.Id).ToList();
        }

        public UploadCategory ById(int id)
        {
            return _uploadCategoryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<UploadCategory, bool>> predicate)
        {
            return _uploadCategoryRepository.SearchFor().Any(predicate);
        }
    }
}
