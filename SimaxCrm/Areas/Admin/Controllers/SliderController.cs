using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Service.Interface;
using System;
using System.IO;
using SimaxCrm.Helper;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class SliderController : BaseAdminController
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public SliderController(ISliderService sliderService,
            IWebHostEnvironment webHostEnvironment)
        {
            _sliderService = sliderService;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_sliderService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Slider obj)
        {
            if (ModelState.IsValid)
            {

                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    var ext = Path.GetExtension(file.FileName);
                    ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Slider, DateTime.Now.ToFileTime().ToString() + ext);
                    await saveFileOnServer(file, imagePath);
                    obj.ImagePath = imagePath.absoluteUrl;
                }
                obj.CreatedBy = base.getUidFromClaim().ToString();
                obj.CreatedDate = DateTime.Now;
                _sliderService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var obj = _sliderService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id, Slider obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    var ext = Path.GetExtension(file.FileName);
                    ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Slider, DateTime.Now.ToFileTime().ToString() + ext);
                    await saveFileOnServer(file, imagePath);
                    obj.ImagePath = imagePath.absoluteUrl;
                }
                var exObj = _sliderService.ById(id, hasTracking: false);
                obj.CreatedBy = exObj.CreatedBy;
                obj.CreatedDate = exObj.CreatedDate;
                obj.UpdatedDate = DateTime.Now;
                obj.UpdatedBy = base.getUidFromClaim().ToString();
                _sliderService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

       
        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _sliderService.ById(id);
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
            _sliderService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
