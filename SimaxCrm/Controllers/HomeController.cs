using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

namespace SimaxCrm.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProjectService _projectService;
        private readonly ISystemSetupService _systemSetupService;
        private readonly ISliderService _sliderService;
        private readonly ISeoService _seoService;
        private readonly ICityService _cityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(IProductService productService,
            IProjectService projectService,
            UserManager<ApplicationUser> userManager,
            ISeoService seoService,
            ISliderService sliderService,
            ICityService cityService,
            ISystemSetupService systemSetupService)
        {
            _sliderService = sliderService;
            _seoService = seoService;
            _userManager = userManager;
            _productService = productService;
            _projectService = projectService;
            _systemSetupService = systemSetupService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            base.LoadViewBagDefaultData(_systemSetupService);
            ViewBag.Slider = _sliderService.List();
            ViewBag.FeaturedProject = _projectService.GetFeaturedProject(0);
            ViewBag.featuredProduct = _productService.GetFeaturedProperty();
            ViewBag.FeaturedAgents = getFeaturedAgents();

            var activeProducts = _productService.ListActive(hasTid: false).Where(m => m.ActiveStatus == Model.Enum.ItemActiveStatusType.Published).ToList();
            base.GetPageMetaTags(_seoService, SeoPage.Home);

            return View();
        }

        private List<ApplicationUser> getFeaturedAgents()
        {

            string[] validRoles = { UserType.Agent.ToString() };
            var user = _userManager.Users.Include(r => r.UserRating).Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                   .Where(m => m.ShowInHomePage)
                   .Take(8)
                   .ToList();

            return user;
        }

        public IActionResult Contact()
        {
            base.LoadViewBagDefaultData(_systemSetupService);
           
            var systemSetup = _systemSetupService.List(hasTid: false).Where(m => m.Status).FirstOrDefault();
            return View(systemSetup);
        }
        public IActionResult Terms()
        {
            base.LoadViewBagDefaultData(_systemSetupService);
            return View();
        }
        public IActionResult Privacy()
        {
            base.LoadViewBagDefaultData(_systemSetupService);
            return View();
        }

        public JsonResult CityList()
        {
            var list = _cityService.List();
            return Json(list);
        }

        [HttpPost]
        public IActionResult Search(MainSearchModel searchModel)
        {
            if (searchModel.TagName == "Project")
            {                
                return RedirectToAction("List", "Projects", new { searchModel.Keyword, searchModel.Location });
            }
            else
            {               
                return RedirectToAction("List", "Properties", new { searchModel.Keyword, searchModel.Location, searchModel.TagName });
            }
        }
    }


}