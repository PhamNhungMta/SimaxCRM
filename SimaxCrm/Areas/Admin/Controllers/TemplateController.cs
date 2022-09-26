using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Service.Interface;
using System;
using System.Threading.Tasks;
using SimaxCrm.Helper;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class TemplateController : Controller
    {
        private readonly ITemplateService _templateService;

        public TemplateController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_templateService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Template obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Type == Model.Enum.TemplateType.Email)
                {
                    obj.Text = obj.TextHtml;
                }
                obj.CreatedDate = DateTime.Now;
                _templateService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var obj = _templateService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Template obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (obj.Type == Model.Enum.TemplateType.Email)
                {
                    obj.Text = obj.TextHtml;
                }
                obj.UpdatedDate = DateTime.Now;
                _templateService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _templateService.ById(id);
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
            _templateService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetByType(TemplateType type)
        {
            var obj = _templateService.ByType(type);
            return Json(obj);
        }

    }
}
