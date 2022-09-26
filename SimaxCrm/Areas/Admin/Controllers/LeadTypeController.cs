using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using System;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class LeadTypeController : BaseAdminController
    {
        private readonly ILeadTypeService _leadTypeService;

        public LeadTypeController(ILeadTypeService leadTypeService)
        {
            _leadTypeService = leadTypeService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_leadTypeService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeadType obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _leadTypeService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _leadTypeService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LeadType obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _leadTypeService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _leadTypeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _leadTypeService.IsAny(e => e.Id == id);
        }
    }
}
