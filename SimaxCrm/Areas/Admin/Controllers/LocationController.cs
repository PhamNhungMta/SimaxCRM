using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class LocationController : BaseAdminController
    {
        private readonly ILocationService _locationService;
        private readonly ICityService _cityService;

        public LocationController(ILocationService locationService,
            ICityService cityService)
        {
            _locationService = locationService;
            _cityService = cityService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_locationService.List());
        }
        public JsonResult List(int cityId)
        {
            var list = _locationService.ListByCityId(cityId);
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
        public IActionResult Create(Location obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedDate = DateTime.Now;
                _locationService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.CityId = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            var obj = _locationService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Location obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _locationService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _locationService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RecordExists(int id)
        {
            return _locationService.IsAny(e => e.Id == id);
        }
    }
}
