using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using SimaxCrm.Helper;
using System.Reflection;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class LeadController : BaseAdminController
    {
        private readonly ILeadService _leadService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly ILeadProductMappingService _leadProductMappingService;
        private readonly ILeadTagService _leadTagService;
        private readonly ILeadTagMappingService _leadTagMappingService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILeadAutoAssignLogService _leadAutoAssignLogService;
        private readonly IProductService _productService;
        private readonly IHelperService _helperService;
        private readonly ISharedService _sharedService;
        private readonly ISystemSetupService _systemSetupService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILocationService _locationService;
        private readonly ITempLeadService _tempLeadService;
        private readonly ISocietyService _societyService;
        private readonly ICallLogService _callLogService;
        private readonly ICityService _cityService;
        private readonly ILeadTypeService _leadTypeService;
        private readonly ICategoryService _categoryService;

        public LeadController(
            ILeadService leadService,
            ILeadSourceService leadSourceService,
            ILeadProductMappingService leadProductMappingService,
            ILeadTagService leadTagService,
            IProductService productService,
            ILeadTagMappingService leadTagMappingService,
            UserManager<ApplicationUser> userManager,
            IHelperService helperService,
            ISystemSetupService systemSetupService,
            ILeadAutoAssignLogService leadAutoAssignLogService,
            IWebHostEnvironment webHostEnvironment,
            ISharedService sharedService,
            ILocationService locationService,
            ISocietyService societyService,
            ICallLogService callLogService,
            ICityService cityService,
            ICategoryService categoryService,
            ILeadTypeService leadTypeService,
            ITempLeadService tempLeadService
            )
        {
            _helperService = helperService;
            _leadService = leadService;
            _leadSourceService = leadSourceService;
            _leadProductMappingService = leadProductMappingService;
            _leadTagService = leadTagService;
            _leadTagMappingService = leadTagMappingService;
            _userManager = userManager;
            _leadAutoAssignLogService = leadAutoAssignLogService;
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;
            _sharedService = sharedService;
            _locationService = locationService;
            _societyService = societyService;
            _callLogService = callLogService;
            _tempLeadService = tempLeadService;
            _cityService = cityService;
            _leadTypeService = leadTypeService;
            _categoryService = categoryService;          
            _systemSetupService = systemSetupService;            
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            var leads = _leadService.List();
            return View(leads);
        }

        // GET: ServiceType/Create
        public IActionResult Create(string contact, string templeadidStr)
        {
            int templeadidInt = base.parseStrIdToId(templeadidStr);
            var systemSetup = _systemSetupService.List(hasTid: false).FirstOrDefault();
            setDefaultData();
            ViewBag.UserIdAgent = getUidFromClaim().ToString();
            if (templeadidInt > 0)
            {
                var tempLead = _tempLeadService.ById(templeadidInt);
                return View(new Lead() {  PhoneNumber = tempLead.PhoneNumber, Name = tempLead.Name, Email = tempLead.Email, TempLeadId = tempLead.Id });
            }
            else
            {
                return View(new Lead() { PhoneNumber = contact });
            }
        }

        private void setDefaultData()
        {
            ViewBag.LeadSourceId = new SelectList(_leadSourceService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.LeadTagId = new SelectList(_leadTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.ProductId = new SelectList(_productService.List(), "Id", "Name");
            ViewBag.CityId = new SelectList(_cityService.List(), "Id", "Name");
            ViewBag.LeadType = new SelectList(_leadTypeService.List(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lead obj)
        {
            if (ModelState.IsValid)
            {
                if (!this.Request.UserIsRole(UserType.Admin))
                {
                    if (string.IsNullOrEmpty(obj.UserId))
                    {
                        obj.UserId = getUidFromClaim().ToString();
                    }
                }

                var systemSetup = _systemSetupService.List(hasTid: false).FirstOrDefault();

                var response = _leadService.CreateLead(obj, getUidFromClaim().ToString());
                if (response.Success)
                {
                    ViewBag.Result = response.Response;
                    setDefaultData();
                    ModelState.Clear();
                    return View(new Lead());
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
        public JsonResult Edit(int id, Lead obj)
        {
            var result = new BaseResponse<string>();
            if (ModelState.IsValid)
            {
                if (obj.BudgetMax < obj.BudgetMin)
                {
                    result.Success = false;
                    result.Response = "Budget max should be greater then budget min";
                    return Json(result);
                }

               
                var existingLead = _leadService.ById(id, hasTid: false);

                var leadUpdateFields = getLeadFieldsDifference(existingLead, obj);

                existingLead.Address = obj.Address;
                existingLead.City = obj.City;
                existingLead.Country = obj.Country;
                existingLead.Email = obj.Email;
                existingLead.LeadSourceId = obj.LeadSourceId;
                existingLead.Name = obj.Name;
                existingLead.PhoneNumber = obj.PhoneNumber;
                existingLead.PostalCode = obj.PostalCode;
                existingLead.PropertyCategoryId = obj.PropertyCategoryId;
                existingLead.BudgetMax = obj.BudgetMax;
                existingLead.BudgetMin = obj.BudgetMin;
                existingLead.CityId = obj.CityId;
                existingLead.State = obj.State;
                existingLead.UpdatedDate = DateTime.Now;
                existingLead.UserId = obj.UserId;
                existingLead.AlternatePhoneNumber = obj.AlternatePhoneNumber;
                existingLead.PropertySubcategoryId = obj.PropertySubcategoryId;
                existingLead.ReferName = obj.ReferName;
                existingLead.ReferPhoneNumber = obj.ReferPhoneNumber;
                existingLead.LeadType = obj.LeadType;
                _leadService.Update(existingLead);

                var existingLeadTagMapping = _leadTagMappingService.ByLeadId(id);
                foreach (var leadTagMapping in existingLeadTagMapping)
                {
                    _leadTagMappingService.Delete(leadTagMapping.Id);
                }

                if (!string.IsNullOrEmpty(obj.LeadTags))
                {
                    foreach (var item in obj.LeadTags.Split(','))
                    {
                        var leadTagMapping = new LeadTagMapping()
                        {
                            Id = 0,
                            LeadId = obj.Id,
                            LeadTagId = int.Parse(item),
                            CreatedDate = DateTime.Now,
                            Status = true,
                        };
                        _leadTagMappingService.Create(leadTagMapping);
                    }
                }


                var existingLeadProductMapping = _leadProductMappingService.ByLeadId(id);
                foreach (var leadProductMapping in existingLeadProductMapping)
                {
                    _leadProductMappingService.Delete(leadProductMapping.Id);
                }

                if (!string.IsNullOrEmpty(obj.ProductIds))
                {
                    foreach (var item in obj.ProductIds.Split(','))
                    {
                        var leadProductMapping = new LeadProductMapping()
                        {
                            Id = 0,
                            LeadId = obj.Id,
                            ProductId = int.Parse(item),
                            CreatedDate = DateTime.Now,
                            Status = true,
                        };
                        _leadProductMappingService.Create(leadProductMapping);
                    }
                }

                var calllog = new CallLog()
                {
                    CreatedDate = DateTime.Now,
                    Id = 0,
                    EndTime = DateTime.Now.TimeOfDay,
                    StartTime = DateTime.Now.TimeOfDay,
                    LeadId = obj.Id,
                    Message = leadUpdateFields,
                    Remarks = "Fields Updated",
                    Status = "Lead",
                    UserId = base.getUidFromClaim().ToString(),
                };
                _callLogService.Create(calllog);

                result.Success = true;
                return Json(result);
            }
            result.Success = false;
            var errors = string.Join(",", ModelState.Values.SelectMany(v => v.Errors).ToList().Select(x => x.ErrorMessage).Distinct().ToList());
            result.Response = errors;
            setDefaultData();
            return Json(result);
        }

        private string getLeadFieldsDifference(Lead existingLead, Lead obj)
        {
            string prop = "";
            PropertyInfo[] properties = typeof(Lead).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var displayNameAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), false);
                var displayName = displayNameAttribute.Length > 0 ? (displayNameAttribute[0] as DisplayAttribute).Name : null;
                if (!string.IsNullOrEmpty(displayName) && displayName != "Total Time" && displayName != "Follow Up")
                {
                    if (existingLead.GetType().GetProperty(property.Name).GetValue(existingLead, null)?.ToString() != obj.GetType().GetProperty(property.Name).GetValue(obj, null)?.ToString())
                    {
                        prop += displayName + ",";
                    }
                }
            }

            return prop.TrimEnd(',').Replace(",", ", ");
        }

        [HttpPost]
        public JsonResult DeleteBulk(Dictionary<string, string> data)
        {
            var ids = data["ids"];
            var userId = data["userId"];

            var leadIds = ids.Split(',').Select(m => Convert.ToInt32(m)).ToArray();

            var leads = _leadService.ByIds(leadIds);
            foreach (var lead in leads)
            {
                lead.LeadStatus = LeadStatusType.Deleted.ToString();
                lead.DeletedById = getUidFromClaim().ToString();
                lead.DeletedDate = DateTime.Now;
                _leadService.Update(lead);
            }
            return Json(new BaseResponse<string>() { Success = true });
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            string returnUrl = data["RetrunUrl"].ToString();
            _leadService.Delete(id, base.getUidFromClaim().ToString());
            return Redirect(returnUrl);
        }

        [HttpPost, ActionName("DeleteDone")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteDoneConfirmed(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            string returnUrl = data["RetrunUrl"].ToString();
            _leadService.DeleteDone(id);
            return Redirect(returnUrl);
        }
        private bool RecordExists(int id)
        {
            return _leadService.IsAny(e => e.Id == id);
        }

        public IActionResult Import()
        {
            return View();
        }

        public IActionResult ImportSample()
        {
            var path = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Sample, "Sample.csv");
            return File(new FileStream(path.physicalPath, FileMode.Open), "application/vnd.ms-excel", "Sample.csv");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportAsync()
        {
            IFormFile file = Request.Form.Files[0];
            var ext = Path.GetExtension(file.FileName);
            ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Excel, DateTime.Now.ToFileTime().ToString() + ext);
            await saveFileOnServer(file, imagePath);

            var dataTable = _sharedService.ExcelToDataSet(imagePath.physicalPath, ext);

            var sources = _leadSourceService.List().Where(m => m.Status);
            var users = _userManager.Users.ToList();

            if (dataTable.Rows.Count > 0)
            {
                var list = new List<Lead>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    var objSource = sources.FirstOrDefault(m => m.Name.ToLower() == dr[2].ToString().ToLower());
                    if (objSource == null)
                    {
                        ViewBag.MessageHtml = "<h2>" + dr[2].ToString().ToLower() + " Source doesn't exists<h2>";
                        return View();
                    }
                }
            }

            if (dataTable.Rows.Count > 0)
            {
                var systemSetup = _systemSetupService.List(hasTid: false).FirstOrDefault();

                var list = new List<Lead>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    var objSource = sources.FirstOrDefault(m => m.Name.ToLower() == dr[2].ToString().ToLower());
                    if (objSource == null)
                    {
                        continue;
                    }

                    var obj = new Lead()
                    {
                        Name = dr[0].ToString(),
                        PhoneNumber = dr[1].ToString(),
                        LeadSourceId = objSource.Id,
                        AlternatePhoneNumber = dr[3].ToString(),
                        Email = dr[4].ToString(),
                        UserId = string.IsNullOrEmpty(dr[5].ToString()) ? null : users.FirstOrDefault(m => m.Name.ToLower() == dr[5].ToString().ToLower() || m.Email.ToLower() == dr[5].ToString().ToLower())?.Id,
                        Id = 0,
                        CreatedDate = DateTime.Now,
                        AssignedDate = DateTime.Now,
                        LeadStatus = LeadStatusType.NewLead.ToString(),
                        LeadType = "",

                        PropertyCategoryId = 0
                    };

                   
                    if (string.IsNullOrEmpty(obj.UserId))
                    {
                        obj.UserId = base.getUidFromClaim().ToString();
                    }


                    if (_leadService.IsAny(m => m.PhoneNumber == obj.PhoneNumber))
                    {
                        continue;
                    }

                    if (!string.IsNullOrEmpty(obj.Email))
                    {
                        if (_leadService.IsAny(m => m.Email == obj.Email))
                        {
                            continue;
                        }
                    }

                    _leadService.Create(obj);
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
