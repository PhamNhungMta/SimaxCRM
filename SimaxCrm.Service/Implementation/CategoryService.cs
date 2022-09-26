using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
           _categoryRepository = categoryRepository;
        }

        public void Create(Category category)
        {
           _categoryRepository.Insert(category);
        }

        public void Delete(int id)
        {
            var obj =_categoryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
           _categoryRepository.Delete(obj);
        }

        public void Update(Category category)
        {
           _categoryRepository.UpdateEntity(category);
        }

        public List<Category> List()
        {
            return _categoryRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Category ById(int id)
        {
            return _categoryRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

        public bool IsAny(Expression<Func<Category, bool>> predicate)
        {
            return _categoryRepository.SearchFor().Any(predicate);
        }
    }
}
