using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using System;
using SimaxCrm.Service.Implementation;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class SubCategoryController : BaseAdminController
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService,
            ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_subCategoryService.List());
        }
        public JsonResult List(int categoryId)
        {
            var list = _subCategoryService.ListByCategoryId(categoryId);
            return Json(list);
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SubCategory obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _subCategoryService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            var obj = _subCategoryService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SubCategory obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _subCategoryService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _subCategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _subCategoryService.IsAny(e => e.Id == id);
        }
    }
}
