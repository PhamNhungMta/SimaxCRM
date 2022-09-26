using Microsoft.AspNetCore.Authorization;
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
    public class SystemSetupController : BaseAdminController
    {
        private readonly ISystemSetupService _systemSetupService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SystemSetupController(ISystemSetupService systemSetupService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _systemSetupService = systemSetupService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_systemSetupService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SystemSetup obj)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files[0];
                    var ext = Path.GetExtension(file.FileName);
                    ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.CompanyLogo, DateTime.Now.ToFileTime().ToString() + ext);
                    await saveFileOnServer(file, imagePath);
                    obj.CompanyLogo = imagePath.absoluteUrl;
                }

                obj.CreatedDate = DateTime.Now;
                _systemSetupService.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _systemSetupService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SystemSetup obj)
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
                    ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.CompanyLogo, DateTime.Now.ToFileTime().ToString() + ext);
                    await saveFileOnServer(file, imagePath);
                    obj.CompanyLogo = imagePath.absoluteUrl;
                }

                obj.UpdatedDate = DateTime.Now;
                _systemSetupService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _systemSetupService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Api()
        {
            return View(_systemSetupService.List());
        }


        private static async Task saveFileOnServer(IFormFile file, ImagePath imagePath)
        {
            using (var inputStream = new FileStream(imagePath.physicalPath, FileMode.Create))
            {
                // read file to stream
                await file.CopyToAsync(inputStream);
                // stream to byte array
                byte[] array = new byte[inputStream.Length];
                inputStream.Seek(0, SeekOrigin.Begin);
                inputStream.Read(array, 0, array.Length);
            }
        }
    }
}
