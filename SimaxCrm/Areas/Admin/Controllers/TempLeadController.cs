using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using SimaxCrm.Helper;
using System.Reflection;
using System.Threading.Tasks;
using SimaxCrm.Areas.Admin.Controllers;

namespace SimaxCrm.Controllers
{
    [CustomAuthorize]
    public class TempLeadController : BaseAdminController
    {
        private readonly ITempLeadService _tempLeadService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHelperService _helperService;
        private readonly ISharedService _sharedService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TempLeadController(
            ITempLeadService tempLeadService,
            UserManager<ApplicationUser> userManager,
            IHelperService helperService,
            IWebHostEnvironment webHostEnvironment,
            ISharedService sharedService
            )
        {
            _helperService = helperService;
            _tempLeadService = tempLeadService;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _sharedService = sharedService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            if (this.Request.UserIsRole(UserType.Admin))
            {
                var tempLeads = _tempLeadService.List().OrderByDescending(m => m.Id).ToList();
                return View(tempLeads);
            }
            else
            {
                var tempLeads = _tempLeadService.ListByUserId(base.getUidFromClaim().ToString());
                return View(tempLeads.OrderByDescending(m => m.Id).ToList());
            }
        }

        // GET: ServiceType/Create
        public IActionResult Create(string contact)
        {
            setDefaultData();
            ViewBag.UserIdAgent = getUidFromClaim().ToString();
            return View(new TempLead() { PhoneNumber = contact });
        }

        private void setDefaultData()
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TempLead obj)
        {
            if (ModelState.IsValid)
            {
                var response = _tempLeadService.CreateTempLead(obj, getUidFromClaim().ToString());
                if (response.Success)
                {
                    ViewBag.Result = response.Response;
                    setDefaultData();
                    ModelState.Clear();
                    return View(new TempLead());
                }
                else
                {
                    setDefaultData();
                    ModelState.AddModelError(response.ModelKey, response.Response);
                    return View(obj);
                }
            }
            setDefaultData();
            return View(obj);
        }


       

        [HttpPost]
        public JsonResult Edit(int id, TempLead obj)
        {
            var result = new BaseResponse<string>();
            if (ModelState.IsValid)
            {
                var existingTempLead = _tempLeadService.ById(id);
                existingTempLead.Email = obj.Email;
                existingTempLead.Name = obj.Name;
                existingTempLead.PhoneNumber = obj.PhoneNumber;
                _tempLeadService.Update(existingTempLead);

                result.Success = true;
                return Json(result);
            }
            result.Success = false;
            var errors = string.Join(",", ModelState.Values.SelectMany(v => v.Errors).ToList().Select(x => x.ErrorMessage).Distinct().ToList());
            result.Response = errors;
            return Json(result);
        }

        private string getTempLeadFieldsDifference(TempLead existingTempLead, TempLead obj)
        {
            string prop = "";
            PropertyInfo[] properties = typeof(TempLead).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var displayNameAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), false);
                var displayName = displayNameAttribute.Length > 0 ? (displayNameAttribute[0] as DisplayAttribute).Name : null;
                if (!string.IsNullOrEmpty(displayName) && displayName != "Total Time" && displayName != "Follow Up")
                {
                    if (existingTempLead.GetType().GetProperty(property.Name).GetValue(existingTempLead, null)?.ToString() != obj.GetType().GetProperty(property.Name).GetValue(obj, null)?.ToString())
                    {
                        prop += displayName + ",";
                    }
                }
            }

            return prop.TrimEnd(',').Replace(",", ", ");

        }



        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            string returnUrl = data["RetrunUrl"].ToString();
            _tempLeadService.Delete(id);
            return Redirect(returnUrl);
        }

        private bool RecordExists(int id)
        {
            return _tempLeadService.IsAny(e => e.Id == id);
        }


        public IActionResult Import()
        {
            return View();
        }

        public IActionResult ImportSample()
        {
            var path = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Sample, "SampleCold.csv");
            return File(new FileStream(path.physicalPath, FileMode.Open), "application/vnd.ms-excel", "SampleCold.csv");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportAsync()
        {
            //var tid = base.getTidFromClaim();
            IFormFile file = Request.Form.Files[0];
            var ext = Path.GetExtension(file.FileName);
            ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Excel, DateTime.Now.ToFileTime().ToString() + ext);
            await saveFileOnServer(file, imagePath);

            var dataTable = _sharedService.ExcelToDataSet(imagePath.physicalPath, ext);

            //var users = _userManager.Users.ToList();

            if (dataTable.Rows.Count > 0)
            {
                var list = new List<TempLead>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    var obj = new TempLead()
                    {
                        Name = dr[0].ToString(),
                        PhoneNumber = dr[1].ToString(),
                        Email = dr[2].ToString(),
                        Id = 0,
                        CreatedDate = DateTime.Now,
                        CreatedBy = base.getUidFromClaim().ToString()
                    };
                    _tempLeadService.Create(obj);
                }
            }
            ViewBag.MessageHtml = "<h2>File Imported Successfully<h2>";
            return View();
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
