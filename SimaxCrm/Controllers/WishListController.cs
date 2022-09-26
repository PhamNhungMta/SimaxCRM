using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Controllers
{
    [AllowAnonymous]
    public class WishListController : BaseController
    {
        private readonly IWishlistService _wishlistService;
        private readonly ISeoService _seoService;
        private readonly ISystemSetupService _systemSetupService;

        public WishListController(IWishlistService wishlistService,
            ISystemSetupService systemSetupService,
            ISeoService seoService
            )
        {
            _seoService = seoService;
            _systemSetupService = systemSetupService;
            _wishlistService = wishlistService;
        }

        [MainCustomAuthorize]
        public IActionResult List()
        {
            var uid = base.getUidFromClaim();
            var wishList = _wishlistService.List(uid.ToString(), include: "Product,Project");
            foreach (var item in wishList)
            {
                if (item.Product != null) item.Product.IsWishlist = true;
                if (item.Project != null) item.Project.IsWishlist = true;
            }
            ViewBag.Product = wishList.Where(m => m.ProductId != null).ToList();
            ViewBag.Project = wishList.Where(m => m.ProjectId != null).ToList();
            base.LoadViewBagDefaultData(_systemSetupService);
            base.GetPageMetaTags(_seoService, SeoPage.Wishlist);
            return View();
        }

        [HttpPost]
        public JsonResult Create(Wishlist obj)
        {
            var uid = base.getUidFromClaim();
            if (uid == null)
            {
                return Json(new BaseResponse<string>() { Success = false });
            }
            var tid = base.getTidFromClaim();
            var list = _wishlistService.List(uid.ToString(), false);
            if (obj.ProjectId != null)
            {
                var item = list.FirstOrDefault(m => m.ProjectId == obj.ProjectId);
                if (item != null)
                {
                    _wishlistService.Delete(item.Id);
                    return Json(new BaseResponse<string>() { Success = true, Response = "removed" });
                }
            }
            if (obj.ProductId != null)
            {
                var item = list.FirstOrDefault(m => m.ProductId == obj.ProductId);
                if (item != null)
                {
                    _wishlistService.Delete(item.Id);
                    return Json(new BaseResponse<string>() { Success = true, Response = "removed" });
                }
            }
            obj.CreatedDate = DateTime.Now;
            obj.UserId = uid.ToString();
            obj.Tid = tid;
            _wishlistService.Create(obj, false);
            return Json(new BaseResponse<string>() { Success = true, Response = "added" });
        }

    }
}