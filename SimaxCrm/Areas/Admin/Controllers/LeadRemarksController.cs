using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using SimaxCrm.Helper;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class LeadRemarksController : BaseAdminController
    {
        private readonly ILeadRemarksService _leadRemarksService;

        public LeadRemarksController(ILeadRemarksService leadRemarksService)
        {
            _leadRemarksService = leadRemarksService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_leadRemarksService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LeadRemarks obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _leadRemarksService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var obj = _leadRemarksService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LeadRemarks obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _leadRemarksService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _leadRemarksService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _leadRemarksService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetByStatus(string status)
        {
            var data = _leadRemarksService.ByStatus(status);
            return Json(data);
        }

    }
}
