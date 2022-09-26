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
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class ProjectController : BaseAdminController
    {
        private readonly IProjectService _projectService;
        private readonly IAttachmentProjectMappingService _attachmentProjectMappingService;
        private readonly IInventoryTagService _inventoryTagService;
        private readonly IProjectTagMappingService _projectTagMappingService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILocationService _locationService;
        private readonly IAttachmentService _attachmentService;
        private readonly ISocietyService _societyService;
        private readonly IUploadCategoryService _uploadCategoryService;
        private readonly IHelperService _helperService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategoryService _categoryService;
        private readonly ICityService _cityService;

        public ProjectController(IProjectService productService,
            IWebHostEnvironment webHostEnvironment,
            IProjectTagMappingService projectTagMappingService,
            IInventoryTagService inventoryTagService,
            ILocationService locationService,
            IAttachmentProjectMappingService attachmentProjectMappingService,
            ISocietyService societyService,
            IAttachmentService attachmentService,
            IUploadCategoryService uploadCategoryService,
            IProjectService projectService,
            IHelperService helperService,
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            ICategoryService categoryService,
            ICityService cityService)
        {
            _projectService = projectService;
            _attachmentProjectMappingService = attachmentProjectMappingService;
            _webHostEnvironment = webHostEnvironment;
            _inventoryTagService = inventoryTagService;
            _projectTagMappingService = projectTagMappingService;
            _locationService = locationService;
            _societyService = societyService;
            _helperService = helperService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _uploadCategoryService = uploadCategoryService;
            _attachmentService = attachmentService;
            _categoryService = categoryService;
            _cityService = cityService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            var model = new ProductsViewFilterModel()
            {
                Status = "",
                CurrentLeadStatus = "",
                UserId = "",
                ActiveStatus = -1
            };

            var uid = base.getUidFromClaim();

            var filteredUsers = base.getAgentList(_userManager);
            var uids = filteredUsers.Select(m => m.Id).ToList();
            uids.Add(uid.ToString());

            if (this.Request.UserIsRole(UserType.Admin) )
            {
                var data = _projectService.List();
                if (model.ActiveStatus != -1)
                {
                    data = data.Where(m => m.ActiveStatus == (ItemActiveStatusType)model.ActiveStatus).ToList();
                }
                return View(data);
            }
            else
            {
                var data = _projectService.ByLeadStatusAndUserId(null, uids, null);
                if (model.ActiveStatus != -1)
                {
                    data = data.Where(m => m.ActiveStatus == (ItemActiveStatusType)model.ActiveStatus).ToList();
                }
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Index(ProductsViewFilterModel model)
        {
            var uid = base.getUidFromClaim();

            var filteredUsers = base.getAgentList(_userManager);
            var uids = filteredUsers.Select(m => m.Id).ToList();
            uids.Add(uid.ToString());

            if (this.Request.UserIsRole(UserType.Admin))
            {
                var data = _projectService.List();
                if (model.ActiveStatus != -1)
                {
                    data = data.Where(m => m.ActiveStatus == (ItemActiveStatusType)model.ActiveStatus).ToList();
                }
                return View(data);
            }
            else
            {
                var data = _projectService.ByLeadStatusAndUserId(null, uids, null);
                if (model.ActiveStatus != -1)
                {
                    data = data.Where(m => m.ActiveStatus == (ItemActiveStatusType)model.ActiveStatus).ToList();
                }
                return View(data);
            }
        }

        // GET: ServiceType/Create
        public IActionResult Create(string contact)
        {
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");

            ViewBag.TempId = Guid.NewGuid().ToString();
            return View(new Project()
            {
                OwnerPhoneNumber = contact
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project obj)
        {
            if (Request.Form.Files["MainImage"] != null)
            {
                var file = Request.Form.Files["MainImage"];
                var ext = Path.GetExtension(file.FileName);
                ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Project, DateTime.Now.ToFileTime().ToString() + ext);
                saveFileOnServer(file, imagePath);
                obj.MainImage = imagePath.absoluteUrl;
            }

            var tempId = obj.TempId;

            obj.CreatedDate = DateTime.Now;
            obj.CreatedBy = base.getUidFromClaim().ToString();
            obj.ActiveStatus = ItemActiveStatusType.Draft;
            obj.Status = ProjectStatusType.Active.ToString();
            _projectService.Create(obj);

            var attachmentList = _attachmentService.ListByTempId(tempId);

            foreach (var attachment in attachmentList)
            {
                var attachmentProjectMapping = new AttachmentProjectMapping()
                {
                    Id = 0,
                    AttachmentId = attachment.Id,
                    UploadCategoryId = attachment.UploadCategoryId,
                    CreatedDate = DateTime.Now,
                    ProjectId = obj.Id,
                    Status = true,
                };
                _attachmentProjectMappingService.Create(attachmentProjectMapping);
            }

            if (!string.IsNullOrEmpty(obj.InventoryTags))
            {
                foreach (var item in obj.InventoryTags.Split(','))
                {
                    var projectTagMapping = new ProjectTagMapping()
                    {
                        Id = 0,
                        ProjectId = obj.Id,
                        InventoryTagId = int.Parse(item),
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    _projectTagMappingService.Create(projectTagMapping);
                }
            }

            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult Edit(string id, bool isView)
        {
            var productId = base.parseStrIdToId(id);
            ViewBag.ProjectId = productId;
            var obj = _projectService.ById(productId);
            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");           
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.IsView = isView;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditView(string id, Project obj)
        {
            var projectId = base.parseStrIdToId(id);

            if (ModelState.IsValid)
            {
                obj = await updateProject(projectId, obj);

                return RedirectToAction("Project", "View", new { Id = base.parseIdToIdStr(projectId, 'E') });
            }
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");           
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.IsView = false;
            ViewBag.ProjectId = projectId;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj = await updateProject(id, obj);
                ViewBag.Result = "Inventory Updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");           
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.IsView = false;
            ViewBag.ProjectId = obj.Id;
            return View(obj);
        }

        private async Task<Project> updateProject(int id, Project obj)
        {

            var existingProject = _projectService.ById(id, hasTracking: false);

            if (Request.Form.Files["MainImage"] != null)
            {
                var file = Request.Form.Files["MainImage"];
                var ext = Path.GetExtension(file.FileName);
                ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Project, DateTime.Now.ToFileTime().ToString() + ext);
                saveFileOnServer(file, imagePath);
                obj.MainImage = imagePath.absoluteUrl;
            }
            else
            {
                obj.MainImage = existingProject.MainImage;
            }

            obj.ViewCount = existingProject.ViewCount;
            obj.CreatedBy = existingProject.CreatedBy;
            obj.CreatedDate = existingProject.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.ActiveStatus = ItemActiveStatusType.Draft;
            _projectService.Update(obj);

            var existingInventoryTagMapping = _projectTagMappingService.ByProjectId(id);
            foreach (var inventoryTagMapping in existingInventoryTagMapping)
            {
                _projectTagMappingService.Delete(inventoryTagMapping.Id);
            }


            if (!string.IsNullOrEmpty(obj.InventoryTags))
            {
                foreach (var item in obj.InventoryTags.Split(','))
                {
                    var projectTagMapping = new ProjectTagMapping()
                    {
                        Id = 0,
                        ProjectId = obj.Id,
                        InventoryTagId = int.Parse(item),
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    _projectTagMappingService.Create(projectTagMapping);
                }
            }

            return obj;
        }

        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _projectService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            _projectService.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("StatusUpdate")]
        [ValidateAntiForgeryToken]
        public IActionResult StatusUpdate(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            int activeStatus = int.Parse(data["ActiveStatus"].ToString());
            var obj = _projectService.ById(id);
            obj.ActiveStatus = (ItemActiveStatusType)activeStatus;
            _projectService.Update(obj);
            return RedirectToAction("Index");
        }

        private void saveFileOnServer(IFormFile file, ImagePath imagePath)
        {
            Image baseImage = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                //var fileBytes = ms.ToArray();
                //string s = Convert.ToBase64String(fileBytes);
                baseImage = Image.FromStream(ms);
            }

            

            watermarkImage(baseImage, imagePath.physicalPath);
        }

        private void watermarkImage(Image image, string imagePath)
        {
            using (Image watermarkImage = Image.FromFile(_webHostEnvironment.ContentRootPath + "\\wwwroot\\images\\watermark.png"))
            using (Graphics imageGraphics = Graphics.FromImage(image))
            using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
            {
                int x = (image.Width / 2 - watermarkImage.Width / 2);
                int y = (image.Height / 2 - watermarkImage.Height / 2);
                watermarkBrush.TranslateTransform(x, y);
                imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                image.Save(imagePath, ImageFormat.Jpeg);
            }
        }
    }
}
