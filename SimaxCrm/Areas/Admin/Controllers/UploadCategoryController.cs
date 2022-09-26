using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using SimaxCrm.Helper;
using System;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class UploadCategoryController : BaseAdminController
    {
        private readonly IUploadCategoryService _uploadCategoryService;

        public UploadCategoryController(IUploadCategoryService uploadCategoryService)
        {
            _uploadCategoryService = uploadCategoryService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_uploadCategoryService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UploadCategory obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _uploadCategoryService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _uploadCategoryService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UploadCategory obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _uploadCategoryService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _uploadCategoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _uploadCategoryService.IsAny(e => e.Id == id);
        }
    }
}
