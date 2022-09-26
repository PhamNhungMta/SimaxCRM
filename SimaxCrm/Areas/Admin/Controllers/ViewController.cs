using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class ViewController : BaseAdminController
    {
        private readonly ILeadService _leadService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly ILeadLanguageService _leadLanguageService;
        private readonly IUploadCategoryService _uploadCategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductService _productService;
        private readonly ILeadTagService _leadTagService;
        private readonly ILeadTagMappingService _leadTagMappingService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILeadTypeService _leadTypeService;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;
        private readonly ILocationService _locationService;
        private readonly ISocietyService _societyService;
        private readonly IInventoryTagService _inventoryTagService;
        private readonly ITcfService _tcfService;

        public ViewController(
            ILeadService leadService,
            ILeadSourceService leadSourceService,
            IUploadCategoryService uploadCategoryService,
            ILeadLanguageService leadLanguageService,
            ILeadTagService leadTagService,
            IProductService productService,
            ILeadTagMappingService leadTagMappingService,
            UserManager<ApplicationUser> userManager,
            ILeadTypeService leadTypeService,
            ICategoryService categoryService,
            ILocationService locationService,
            ISocietyService societyService,
            ICityService cityService,
            IInventoryTagService inventoryTagService,
            ITcfService tcfService,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _uploadCategoryService = uploadCategoryService;
            _webHostEnvironment = webHostEnvironment;
            _tcfService = tcfService;
            _leadService = leadService;
            _leadSourceService = leadSourceService;
            _leadLanguageService = leadLanguageService;
            _productService = productService;
            _leadTagService = leadTagService;
            _leadTagMappingService = leadTagMappingService;
            _userManager = userManager;
            _leadTypeService = leadTypeService;
            _categoryService = categoryService;
            _cityService = cityService;
            _locationService = locationService;
            _societyService = societyService;
            _inventoryTagService = inventoryTagService;
        }

        public IActionResult Leads(string id)
        {
            var model = new LeadsViewFilterModel()
            {
                LeadStatus = id,
                CurrentLeadStatus = id,
                UserId = ""
            };
            List<Lead> leads = getLeadsByLeadStatus(model);
            ViewBag.Title = id;
            ViewBag.AllLead = model;
            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.LeadType = new SelectList(_leadTypeService.List(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
            ViewBag.CityId = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View(leads);
        }

        private List<Lead> getLeadsByLeadStatus(LeadsViewFilterModel leadsViewFilterModel)
        {
            var loggedUid = getUidFromClaim().ToString();
            var uids = new List<string>();
            if (this.Request.UserIsRole(UserType.Admin))
            {
                uids = null;
            }
            else
            {
                var filteredUsers = base.getAgentList(_userManager);
                uids = filteredUsers.Select(m => m.Id).ToList();
            }

            List<Lead> leads = null;

            if (!string.IsNullOrEmpty(leadsViewFilterModel.UserId))
            {
                uids = new List<string>();
                uids.Add(Guid.Parse(leadsViewFilterModel.UserId).ToString());
            }

            if (leadsViewFilterModel.LeadStatus.ToLower() == "MissedFollowUp".ToLower())
            {
                leads = _leadService.ByLeadStatusAndUserId("FollowUp", uids, leadsViewFilterModel.StartDate, leadsViewFilterModel.EndDate);
                leads = leads.Where(m => m.AlertDate.Value.Date < DateTime.Now.Date).ToList();
            }
            else if (leadsViewFilterModel.LeadStatus.ToLower() == "FollowUp".ToLower())
            {
                leads = _leadService.ByLeadStatusAndUserId(leadsViewFilterModel.LeadStatus, uids, leadsViewFilterModel.StartDate, leadsViewFilterModel.EndDate);
                leads = leads.Where(m => m.AlertDate.Value.Date == DateTime.Now.Date).ToList();
            }
            else if (leadsViewFilterModel.LeadStatus.ToLower() == "AllFollowUp".ToLower())
            {
                leads = _leadService.ByLeadStatusAndUserId("FollowUp", uids, leadsViewFilterModel.StartDate, leadsViewFilterModel.EndDate);
                leads = leads.Where(m => m.AlertDate.Value.Date != null).ToList();
            }
            else if (leadsViewFilterModel.LeadStatus.ToLower() == "AllLead".ToLower())
            {
                leads = _leadService.ByUserIds(uids, leadsViewFilterModel.StartDate, leadsViewFilterModel.EndDate, leadsViewFilterModel.LeadStatus);
            }

            else
            {
                leads = _leadService.ByLeadStatusAndUserId(leadsViewFilterModel.LeadStatus, uids, leadsViewFilterModel.StartDate, leadsViewFilterModel.EndDate);
            }


            if (!string.IsNullOrEmpty(leadsViewFilterModel.LeadType))
            {
                leads = leads.Where(m => m.LeadType == leadsViewFilterModel.LeadType).ToList();
            }

            if (leadsViewFilterModel.PropertyCategoryId > 0)
            {
                leads = leads.Where(m => m.PropertyCategoryId == leadsViewFilterModel.PropertyCategoryId).ToList();
            }

            if (leadsViewFilterModel.PropertySubcategoryId > 0)
            {
                leads = leads.Where(m => m.PropertySubcategoryId == leadsViewFilterModel.PropertySubcategoryId).ToList();
            }

            if (leadsViewFilterModel.Budget.HasValue && leadsViewFilterModel.Budget > 0)
            {
                leads = leads.Where(m => leadsViewFilterModel.Budget >= m.BudgetMin && leadsViewFilterModel.Budget <= m.BudgetMax).ToList();
            }

            return leads.OrderByDescending(m => m.Id).ToList();
        }

        [HttpPost]
        public IActionResult Leads(LeadsViewFilterModel model)
        {
            List<Lead> leads = getLeadsByLeadStatus(model);
            ViewBag.Title = model.CurrentLeadStatus;
            ViewBag.AllLead = model;
            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.LeadType = new SelectList(_leadTypeService.List(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
            ViewBag.LocationId = new SelectList(_locationService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.SocietyId = new SelectList(_societyService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View(leads);
        }

        public IActionResult Lead(string id)
        {
            var leadId = base.parseStrIdToId(id);
            ViewBag.LeadId = leadId;

            var lead = _leadService.ById(leadId, hasTid: false);

            ViewBag.LeadSourceId = new SelectList(_leadSourceService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.ProductId = new SelectList(_productService.List(), "Id", "Name");
            ViewBag.LeadTagId = new SelectList(_leadTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.LeadType = new SelectList(_leadTypeService.List(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
            ViewBag.CityId = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View(lead);
        }

        public IActionResult TCF(string id)
        {
            var leadId = base.parseStrIdToId(id);
            ViewBag.LeadId = leadId;

            var tcf = _tcfService.ByLeadId(leadId);
            if (tcf == null)
            {
                var lead = _leadService.ById(leadId);
                tcf = new Tcf()
                {
                    Id = 0,
                    LeadId = lead.Id,
                };
            }
            return View(tcf);
        }

        [HttpPost]
        public async Task<IActionResult> TCF(Tcf obj)
        {
            if (Request.Form.Files.Count > 0)
            {
                foreach (var file in Request.Form.Files)
                {
                    var ext = Path.GetExtension(file.FileName);
                    ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Product, DateTime.Now.ToFileTime().ToString() + ext);
                    await saveFileOnServerAsync(file, imagePath);
                    setImagePathProperty(ref obj, imagePath.absoluteUrl, file.Name);
                }
            }

            var extcf = _tcfService.ByLeadId(obj.LeadId);
            if (extcf != null)
            {
                obj.Id = extcf.Id;
            }
            if (obj.Id == 0)
            {
                _tcfService.Create(obj);
            }
            else
            {
                _tcfService.Update(obj);
            }

            ViewBag.Result = "Saved Successfully";

            var lead = _leadService.ById(obj.LeadId);
            return RedirectToAction("TCF", new { id = lead.IdStr });
        }

        private async Task saveFileOnServerAsync(IFormFile file, ImagePath imagePath)
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

        private void setImagePathProperty(ref Tcf obj, string absoluteUrl, string name)
        {
            switch (name)
            {
                case "BookingForm":
                    obj.BookingForm = absoluteUrl;
                    break;
                case "PaymentDetails":
                    obj.PaymentDetails = absoluteUrl;
                    break;
                case "OpsChecklist":
                    obj.OpsChecklist = absoluteUrl;
                    break;
                case "DiscountApproval":
                    obj.DiscountApproval = absoluteUrl;
                    break;
                case "AadharCard":
                    obj.AadharCard = absoluteUrl;
                    break;
                case "PanCard":
                    obj.PanCard = absoluteUrl;
                    break;
                case "VoterID":
                    obj.VoterID = absoluteUrl;
                    break;
                case "Passport":
                    obj.Passport = absoluteUrl;
                    break;
            }
        }

        public IActionResult Products(string id)
        {
            var model = new ProductsViewFilterModel()
            {
                Status = id,
                CurrentLeadStatus = id,
                UserId = "",
                ActiveStatus = -1
            };
            model.CurrentUid = base.getUidFromClaim().ToString();
            List<Product> leads = getProductsByStatus(model);
            ViewBag.Title = id;
            ViewBag.AllProduct = model;
            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
            ViewBag.LocationId = new SelectList(_locationService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.SocietyId = new SelectList(_societyService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View(leads);
        }

        [HttpPost]
        public IActionResult Products(ProductsViewFilterModel model)
        {
            model.CurrentUid = base.getUidFromClaim().ToString();
            var leads = getProductsByStatus(model);
            ViewBag.Title = model.CurrentLeadStatus;
            ViewBag.AllProduct = model;
            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
            ViewBag.LocationId = new SelectList(_locationService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.SocietyId = new SelectList(_societyService.List().Where(m => m.Status).ToList(), "Id", "Name");

            return View(leads);
        }

        private List<Product> getProductsByStatus(ProductsViewFilterModel model)
        {
            var uids = new List<string>();
            if (this.Request.UserIsRole(UserType.Admin))
            {
                uids = null;
            }
            else
            {
                var filteredUsers = base.getAgentList(_userManager);
                uids = filteredUsers.Select(m => m.Id).ToList();
                uids.Add(model.CurrentUid);
            }

            List<Product> leads = null;

            if (!string.IsNullOrEmpty(model.UserId))
            {
                uids = new List<string>();
                uids.Add(Guid.Parse(model.UserId).ToString());
            }

            if (model.Status.ToLower() == "productmissedfollowup")
            {
                leads = _productService.ByLeadStatusAndUserId("FollowUp", uids, model);
                leads = leads.Where(m => m.AlertDate.Value.Date < DateTime.Now.Date).ToList();
            }
            else if (model.Status.ToLower() == "productfollowup")
            {
                leads = _productService.ByLeadStatusAndUserId("FollowUp", uids, model);
                leads = leads.Where(m => m.AlertDate.Value.Date == DateTime.Now.Date).ToList();
            }
            else if (model.Status.ToLower() == "productmyfollowup")
            {
                leads = _productService.ByLeadStatusAndUserId("FollowUp", uids, model);
                leads = leads.ToList();
            }
            else if (model.Status.ToLower() == "allproduct")
            {
                leads = _productService.ByLeadStatusAndUserId(null, uids, model);
            }
            else
            {
                leads = _productService.ByLeadStatusAndUserId(model.Status, uids, model);
            }

            return leads.OrderByDescending(m => m.Id).ToList();
        }

        public IActionResult Product(string id)
        {
            var productId = base.parseStrIdToId(id);
            ViewBag.ProductId = productId;
            var product = _productService.ById(productId);
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.CategoryId = new SelectList(_categoryService.List(), "Id", "Name");
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            
            ViewBag.IsView = false;
            return View(product);
        }

        [HttpPost]
        public JsonResult ReAssign(Dictionary<string, string> data)
        {
            var ids = data["ids"];
            var userId = data["userId"];

            var leadIds = ids.Split(',').Select(m => Convert.ToInt32(m)).ToArray();

            var leads = _leadService.ByIds(leadIds);
            foreach (var lead in leads)
            {
                lead.UserId = userId;
                lead.AssignedDate = DateTime.Now;
                _leadService.Update(lead);
            }
            return Json(new BaseResponse<string>() { Success = true });
        }

        [HttpGet]
        public JsonResult Matching(int leadId)
        {
            var uid = base.getUidFromClaim().ToString();
            //var tid = base.getTidFromClaim();
            var leads = _leadService.ById(leadId);
            var products = _productService.GetMatchingByLead(leads);
            var users = _userManager.Users.ToList();
            foreach (var item in products)
            {
                if (item.CreatedBy == uid)
                    item.CanView = true;
                else
                    item.CanView = false;

                var user = users.FirstOrDefault(m => m.Id == item.CreatedBy);
                if (user != null)
                {
                    item.UserStr = user.Name + " (" + user.PhoneNumber + ")";
                }
            }
            return Json(products);
        }

        [HttpPost]
        public JsonResult SaveMaster(Dictionary<string, string> data)
        {
            var name = data["name"];
            var field = data["field"];
            var cityId = int.Parse(data["cityId"]);

            switch (field)
            {
                case "LocationId":
                case "LeadLocationMulti":
                    var objLocation = new Location()
                    {
                        Id = 0,
                        CreatedDate = DateTime.Now,
                        CityId = cityId,
                        Name = name,
                        Status = true,
                    };
                    _locationService.Create(objLocation);
                    return Json(_locationService.List().Where(m => m.Status).ToList());

                case "SocietyId":
                case "LeadSocietyMulti":
                    var objSociety = new Society()
                    {
                        Id = 0,
                        CreatedDate = DateTime.Now,
                        CityId = cityId,
                        Name = name,
                        Status = true,
                    };
                    _societyService.Create(objSociety);
                    return Json(_societyService.List().Where(m => m.Status).ToList());
            }

            return Json(null);
        }



        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("ProductStatusUpdate")]
        [ValidateAntiForgeryToken]
        public IActionResult ProductStatusUpdate(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            int activeStatus = int.Parse(data["ActiveStatus"].ToString());
            var obj = _productService.ById(id);
            obj.ActiveStatus = (ItemActiveStatusType)activeStatus;
            _productService.Update(obj);
            return RedirectToAction("Products", "View", new { id = "allproduct" });
        }
    }
}

