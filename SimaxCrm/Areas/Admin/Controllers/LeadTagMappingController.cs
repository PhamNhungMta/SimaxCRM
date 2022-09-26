using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using System;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class LeadTagMappingController : BaseAdminController
    {
        private readonly ILeadTagMappingService _leadTagMappingService;

        public LeadTagMappingController(ILeadTagMappingService leadTagMappingService)
        {
            _leadTagMappingService = leadTagMappingService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_leadTagMappingService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeadTagMapping obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _leadTagMappingService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _leadTagMappingService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LeadTagMapping obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _leadTagMappingService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _leadTagMappingService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _leadTagMappingService.IsAny(e => e.Id == id);
        }
    }
}
