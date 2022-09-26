using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class SocietyController : BaseAdminController
    {
        private readonly ISocietyService _societyService;
        private readonly ICityService _cityService;

        public SocietyController(ISocietyService societyService,
            ICityService cityService)
        {
            _societyService = societyService;
            _cityService = cityService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_societyService.List());
        }
        public JsonResult List(int cityId)
        {
            var list = _societyService.ListByCityId(cityId);
            return Json(list);
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            ViewBag.CityId = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Society obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _societyService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.CityId = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            var obj = _societyService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Society obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _societyService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _societyService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _societyService.IsAny(e => e.Id == id);
        }
    }
}
