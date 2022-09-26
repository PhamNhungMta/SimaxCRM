using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using System;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_categoryService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _categoryService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _categoryService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _categoryService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _categoryService.IsAny(e => e.Id == id);
        }
    }
}
