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
    public class ProductController : BaseAdminController
    {
        private readonly IProductService _productService;
        private readonly IAttachmentProductMappingService _attachmentProductMappingService;
        private readonly IInventoryTagService _inventoryTagService;
        private readonly IInventoryTagMappingService _inventoryTagMappingService;
        private readonly IWebHostEnvironment _webHostEnvironment;       
        private readonly IAttachmentService _attachmentService;
        private readonly IProjectService _projectService;
        private readonly IUploadCategoryService _uploadCategoryService;
        private readonly IHelperService _helperService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICategoryService _categoryService;        
        private readonly ICityService _cityService;

        public ProductController(IProductService productService,
            IWebHostEnvironment webHostEnvironment,
            IInventoryTagMappingService inventoryTagMappingService,
            IInventoryTagService inventoryTagService,          
            IAttachmentProductMappingService attachmentProductMappingService,
            IAttachmentService attachmentService,
            IUploadCategoryService uploadCategoryService,
            IProjectService projectService,
            IHelperService helperService,
            IHttpContextAccessor httpContextAccessor,
            ICategoryService categoryService,          
            ICityService cityService,
            UserManager<ApplicationUser> userManager)
        {
            _projectService = projectService;
            _productService = productService;
            _attachmentProductMappingService = attachmentProductMappingService;
            _webHostEnvironment = webHostEnvironment;
            _inventoryTagService = inventoryTagService;
            _inventoryTagMappingService = inventoryTagMappingService;
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
            var uid = base.getUidFromClaim();

            var filteredUsers = base.getAgentList(_userManager);
            var uids = filteredUsers.Select(m => m.Id).ToList();

            if (this.Request.UserIsRole(UserType.Admin))
            {
                return View(_productService.List());
            }
            else
            {
                return View(_productService.ByLeadStatusAndUserId(null, uids, null));
            }
        }

        // GET: ServiceType/Create
        public IActionResult Create(string contact)
        {
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.ProjectId = new SelectList(_projectService.List(), "Id", "Name");
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");           
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");        
            ViewBag.TempId = Guid.NewGuid().ToString();
            return View(new Product()
            {
                OwnerPhoneNumber = contact
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product obj)
        {
            if (Request.Form.Files["MainImage"] != null)
            {
                var file = Request.Form.Files["MainImage"];
                var ext = Path.GetExtension(file.FileName);
                ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Product, DateTime.Now.ToFileTime().ToString() + ext);
                saveFileOnServer(file, imagePath);
                obj.MainImage = imagePath.absoluteUrl;
            }

            var tempId = obj.TempId;

            obj.ActiveStatus = ItemActiveStatusType.Draft;
            obj.CreatedDate = DateTime.Now;
            obj.CreatedBy = base.getUidFromClaim().ToString();
            _productService.Create(obj);

            var attachmentList = _attachmentService.ListByTempId(tempId);

            foreach (var attachment in attachmentList)
            {
                var attachmentProductMapping = new AttachmentProductMapping()
                {
                    Id = 0,
                    AttachmentId = attachment.Id,
                    UploadCategoryId = attachment.UploadCategoryId,
                    CreatedDate = DateTime.Now,
                    ProductId = obj.Id,
                    Status = true,
                };
                _attachmentProductMappingService.Create(attachmentProductMapping);
            }

            if (!string.IsNullOrEmpty(obj.InventoryTags))
            {
                foreach (var item in obj.InventoryTags.Split(','))
                {
                    var leadTagMapping = new InventoryTagMapping()
                    {
                        Id = 0,
                        ProductId = obj.Id,
                        InventoryTagId = int.Parse(item),
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    _inventoryTagMappingService.Create(leadTagMapping);
                }
            }
          
            return RedirectToAction("Products", "View", new { id = "allproduct" });

        }

        private void setImagePathProperty(ref Product obj, string absoluteUrl, string name)
        {
            switch (name)
            {
                case "PostImagePath1":
                    obj.ImagePath1 = absoluteUrl;
                    break;
                case "PostImagePath2":
                    obj.ImagePath2 = absoluteUrl;
                    break;
                case "PostImagePath3":
                    obj.ImagePath3 = absoluteUrl;
                    break;
                case "PostImagePath4":
                    obj.ImagePath4 = absoluteUrl;
                    break;
                case "PostImagePath5":
                    obj.ImagePath5 = absoluteUrl;
                    break;
                case "PostImagePath6":
                    obj.ImagePath6 = absoluteUrl;
                    break;
                case "PostImagePath7":
                    obj.ImagePath7 = absoluteUrl;
                    break;
                case "PostImagePath8":
                    obj.ImagePath8 = absoluteUrl;
                    break;
                case "PostImagePath9":
                    obj.ImagePath9 = absoluteUrl;
                    break;
                case "PostImagePath10":
                    obj.ImagePath10 = absoluteUrl;
                    break;
            }
        }

        public IActionResult Edit(string id, bool isView)
        {
            var productId = base.parseStrIdToId(id);
            ViewBag.ProductId = productId;
            var obj = _productService.ById(productId);
            if (obj == null)
            {
                return NotFound();
            }
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.ProjectId = new SelectList(_projectService.List(), "Id", "Name");
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.CategoryId = new SelectList(_categoryService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.IsView = isView;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditView(string id, Product obj)
        {
            var productId = base.parseStrIdToId(id);


            if (ModelState.IsValid)
            {
                obj = await updateProduct(productId, obj);

                return RedirectToAction("Product", "View", new { Id = base.parseIdToIdStr(productId, 'P') });
            }
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.ProjectId = new SelectList(_projectService.List(), "Id", "Name");
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.IsView = false;
            ViewBag.ProductId = productId;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj = await updateProduct(id, obj);
                ViewBag.Result = "Inventory Updated Successfully";
            }
            ViewBag.InventoryTagId = new SelectList(_inventoryTagService.List().Where(m => m.Status).ToList(), "Id", "Name");
            ViewBag.ProjectId = new SelectList(_projectService.List(), "Id", "Name");
            ViewBag.UploadCategory = _uploadCategoryService.List(hasTid: false).Where(m => m.Status).ToList();
            ViewBag.IsView = false;
            ViewBag.ProductId = obj.Id;
            if (HttpContext.Request.Headers["Referer"].First().IndexOf("product/edit") != -1)
            {
                return RedirectToAction("Edit", new { id = obj.IdStr, isView = false });
            }
            else
            {
                return RedirectToAction("Product", "View", new { id = obj.IdStr });
            }
        }

        private async Task<Product> updateProduct(int id, Product obj)
        {
            var existingProduct = _productService.ById(id, hasTracking: false);
            if (Request.Form.Files["MainImage"] != null)
            {
                var file = Request.Form.Files["MainImage"];
                var ext = Path.GetExtension(file.FileName);
                ImagePath imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, FolderType.Product, DateTime.Now.ToFileTime().ToString() + ext);
                saveFileOnServer(file, imagePath);
                obj.MainImage = imagePath.absoluteUrl;
            }
            else
            {
                obj.MainImage = existingProduct.MainImage;
            }


            obj.ViewCount = existingProduct.ViewCount;
            obj.CreatedBy = existingProduct.CreatedBy;
            obj.CreatedDate = existingProduct.CreatedDate;
            obj.UpdatedDate = DateTime.Now;
            obj.ActiveStatus = existingProduct.ActiveStatus;

            _productService.Update(obj);

            var existingInventoryTagMapping = _inventoryTagMappingService.ByProductId(id);
            foreach (var inventoryTagMapping in existingInventoryTagMapping)
            {
                _inventoryTagMappingService.Delete(inventoryTagMapping.Id);
            }


            if (!string.IsNullOrEmpty(obj.InventoryTags))
            {
                foreach (var item in obj.InventoryTags.Split(','))
                {
                    var leadTagMapping = new InventoryTagMapping()
                    {
                        Id = 0,
                        ProductId = obj.Id,
                        InventoryTagId = int.Parse(item),
                        CreatedDate = DateTime.Now,
                        Status = true,
                    };
                    _inventoryTagMappingService.Create(leadTagMapping);
                }
            }

            return obj;
        }

        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _productService.ById(id);
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
            string returnUrl = data["RetrunUrl"].ToString();
            _productService.Delete(id);
            return Redirect(returnUrl);
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
