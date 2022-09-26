using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }

        public void Create(SubCategory subCategory)
        {
            _subCategoryRepository.Insert(subCategory);
        }

        public void Delete(int id)
        {
            var obj = _subCategoryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _subCategoryRepository.Delete(obj);
        }

        public void Update(SubCategory subCategory)
        {
            _subCategoryRepository.UpdateEntity(subCategory);
        }

        public List<SubCategory> List()
        {
            return _subCategoryRepository.SearchFor(null, "Category").OrderByDescending(x => x.Id).ToList();
        }

        public List<SubCategory> ListByCategoryId(int categoryId)
        {
            return _subCategoryRepository.SearchFor(x => x.CategoryId == categoryId).OrderByDescending(x => x.Id).ToList();
        }

        public SubCategory ById(int id)
        {
            return _subCategoryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<SubCategory, bool>> predicate)
        {
            return _subCategoryRepository.SearchFor().Any(predicate);
        }

        public List<SubCategory> ByIds(List<int> ids)
        {
            return _subCategoryRepository.SearchFor(x => ids.Contains(x.Id)).OrderByDescending(x => x.Id).ToList();
        }
    }
}
