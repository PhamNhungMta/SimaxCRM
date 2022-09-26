using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Controllers
{
    public class PropertiesController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IWishlistService _wishlistService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISeoService _seoService;
        private readonly ISystemSetupService _systemSetupService;
        private readonly ICityService _cityService;

        public PropertiesController(IProductService productService,
            IWishlistService wishlistService,
            UserManager<ApplicationUser> userManager,
            ISystemSetupService systemSetupService,
            ISeoService seoService,
            ICityService cityService
            )
        {
            _userManager = userManager;
            _seoService = seoService;
            _systemSetupService = systemSetupService;
            _productService = productService;
            _wishlistService = wishlistService;
            _cityService = cityService;
        }

        public IActionResult List(string keyword, string location, string tagName, string propertyType, string category)
        {           
            ViewBag.SearchModel = new MainSearchModel()
            {
                Keyword = keyword,
                Location = location,
                TagName = tagName,
                PropertyType = propertyType,
                Category = category
            };
            base.LoadViewBagDefaultData(_systemSetupService);
            base.GetPageMetaTags(_seoService, SeoPage.Properties);
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View();
        }

        public IActionResult Single(int id, string name)
        {
            var product = _productService.ById(id);
            product.ViewCount = product.ViewCount + 1;
            _productService.Update(product);

            ViewBag.RelatedProducts = _productService.GetRelatedProjects(product);
            base.LoadViewBagDefaultData(_systemSetupService);

            var user = _userManager.Users.FirstOrDefault(m => m.Id == product.CreatedBy);
            ViewBag.User = user;

            ViewData["Title"] = product.Name;
            ViewData["MetaKeyword"] = product.MetaTag;
            ViewData["MetaDescription"] = product.MetaDescription;

            return View(product);
        }

        [HttpPost]
        public IActionResult ListAjax(ProductMainFilterModel filterModel)
        {
            var projects = _productService.ListByFilter(filterModel);
            var uid = base.getUidFromClaim();
            if (uid != null)
            {
                var wishlist = _wishlistService.List(uid.ToString(), false);
                if (wishlist.Count > 0)
                {
                    foreach (var item in projects.List)
                    {
                        if (wishlist.Any(m => m.ProductId == item.Id))
                        {
                            item.IsWishlist = true;
                        }
                    }
                }
            }

            return View("/Views/Properties/_ListAjax.cshtml", projects);
        }

    }
}