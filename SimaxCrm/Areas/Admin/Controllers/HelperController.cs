using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using SimaxCrm.Helper;
using System;
using System.Linq;
using SimaxCrm.Model.RequestModel;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class HelperController : BaseAdminController
    {
        private readonly IUploadCategoryService _uploadCategoryService;
        private readonly IAttachmentService _attachmentService;
        private readonly IAttachmentProductMappingService _attachmentProductMappingService;
        private readonly IAttachmentProjectMappingService _attachmentProjectMappingService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HelperController(IUploadCategoryService uploadCategoryService,
            IWebHostEnvironment webHostEnvironment,
            IAttachmentService attachmentService,
            IAttachmentProductMappingService attachmentProductMappingService,
            IAttachmentProjectMappingService attachmentProjectMappingService)
        {
            _uploadCategoryService = uploadCategoryService;
            _webHostEnvironment = webHostEnvironment;
            _attachmentService = attachmentService;
            _attachmentProductMappingService = attachmentProductMappingService;
            _attachmentProjectMappingService = attachmentProjectMappingService;
        }

        public IActionResult UploadFile(int folderType, int? uploadCategory, string tempId, int recId, bool isView)
        {
            ViewBag.folderType = folderType;
            ViewBag.uploadCategory = uploadCategory;
            ViewBag.tempId = tempId;
            ViewBag.recId = recId;
            ViewBag.isView = isView;
            List<Attachment> list = null;
            if (!string.IsNullOrEmpty(tempId))
            {
                list = _attachmentService.ListByFolderCateTempId(uploadCategory, tempId);
            }
            else
            {
                if (((FolderType)folderType) == FolderType.Product)
                {
                    var mappingList = _attachmentProductMappingService.ListByProductId(recId);
                    list = mappingList.Select(m => m.Attachment).Where(m => m.UploadCategoryId == uploadCategory).ToList();
                }
                else if (((FolderType)folderType) == FolderType.Project)
                {
                    var mappingList = _attachmentProjectMappingService.ListByProjectId(recId);
                    list = mappingList.Select(m => m.Attachment).Where(m => m.UploadCategoryId == uploadCategory).ToList();
                }
            }
            return View(list);
        }

        [HttpPost]
        public async Task<JsonResult> UploadFile(object obj)
        {
            if (Request.Form["action"] == "Upload")
            {
                var folderType = (FolderType)int.Parse(HttpContext.Request.Form["folderType"]);
                int.TryParse(Request.Form["uploadCategoryId"], out int outCateId);
                int? uploadCategoryId = outCateId == 0 ? (int?)null : outCateId;
                var tempId = Request.Form["tempId"];
                var recId = int.Parse(Request.Form["recId"]);

                var myfile = HttpContext.Request.Form.Files["myfile"];
                if (myfile != null)
                {
                    var ext = Path.GetExtension(myfile.FileName);
                    var imagePath = new ImagePath(_webHostEnvironment.ContentRootPath, folderType, DateTime.Now.ToFileTime() + "_" + myfile.FileName);
                    await saveFileOnServerAsync(myfile, imagePath);
                    /*
                     * TODO : images aray [".jpg",".jpeg',]
                     * contain with ext variable
                     * set water mark, copy from product controller
                     * save


                    */
                    var attachment = new Attachment()
                    {
                        Id = 0,
                        FilePath = imagePath.absoluteUrl,
                        FileName = imagePath.filename,
                        CreatedDate = DateTime.Now,
                        CreatedBy = base.getUidFromClaim().ToString(),
                        UploadCategoryId = uploadCategoryId,
                        FileSize = myfile.Length,
                        Status = true,
                        FileType = ext,
                        TempId = tempId
                    };

                    _attachmentService.Create(attachment);

                    if (recId > 0)
                    {
                        if (((FolderType)folderType) == FolderType.Product)
                        {
                            var attachmentProductMapping = new AttachmentProductMapping()
                            {
                                Id = 0,
                                AttachmentId = attachment.Id,
                                UploadCategoryId = attachment.UploadCategoryId,
                                CreatedDate = DateTime.Now,
                                ProductId = recId,
                                Status = true,
                            };
                            _attachmentProductMappingService.Create(attachmentProductMapping);
                        }
                        else if (((FolderType)folderType) == FolderType.Project)
                        {
                            var attachmentProjectMapping = new AttachmentProjectMapping()
                            {
                                Id = 0,
                                AttachmentId = attachment.Id,
                                UploadCategoryId = attachment.UploadCategoryId,
                                CreatedDate = DateTime.Now,
                                ProjectId = recId,
                                Status = true,
                            };
                            _attachmentProjectMappingService.Create(attachmentProjectMapping);
                        }
                    }
                }
            }
            else if (Request.Form["action"] == "Delete")
            {
                int attachmentid = int.Parse(Request.Form["attachmentid"]);
                _attachmentService.Delete(attachmentid);
            }

            return Json(null);
        }

        private async Task saveFileOnServerAsync(IFormFile file, ImagePath imagePath)
        {
            Image baseImage = null;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                //var fileBytes = ms.ToArray();
                //string s = Convert.ToBase64String(fileBytes);
                baseImage = Image.FromStream(ms);
            }

            using (var inputStream = new FileStream(imagePath.physicalPath, FileMode.Create))
            {
                // read file to stream
                await file.CopyToAsync(inputStream);
                // stream to byte array
                byte[] array = new byte[inputStream.Length];
                inputStream.Seek(0, SeekOrigin.Begin);
                inputStream.Read(array, 0, array.Length);
            }

            var ext = Path.GetExtension(file.FileName);
            string[] extList = { ".jpg", ".jpeg", ".png", ".gif" };
            int pos = Array.IndexOf(extList, ext);
            if (pos > -1)
            {
                watermarkImage(baseImage, imagePath.physicalPath);
            }
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
        [HttpGet]
        public IActionResult NewUploadRow()
        {
            var category = _uploadCategoryService.List().Where(m => m.Status).ToList();
            return View("Helper/_FileUploadRow", category);
        }
    }


}
