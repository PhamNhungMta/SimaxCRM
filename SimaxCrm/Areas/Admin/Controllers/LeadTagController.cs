using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using SimaxCrm.Helper;
using System;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class LeadTagController : BaseAdminController
    {
        private readonly ILeadTagService _leadTagService;

        public LeadTagController(ILeadTagService leadTagService)
        {
            _leadTagService = leadTagService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_leadTagService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeadTag obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _leadTagService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _leadTagService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LeadTag obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _leadTagService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _leadTagService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _leadTagService.IsAny(e => e.Id == id);
        }
    }
}
