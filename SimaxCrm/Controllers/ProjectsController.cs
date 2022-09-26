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
    public class ProjectsController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISeoService _seoService;
        private readonly ISystemSetupService _systemSetupService;
        private readonly IProjectService _projectService;
        private readonly IWishlistService _wishlistService;
        private readonly ICityService _cityService;

        public ProjectsController(IProjectService projectService,
            IWishlistService wishlistService, 
            ISeoService seoService,
            UserManager<ApplicationUser> userManager,
            ISystemSetupService systemSetupService,
            ICityService cityService
            )
        {
            _userManager = userManager;
            _seoService = seoService;
            _systemSetupService = systemSetupService;
            _projectService = projectService;
            _wishlistService = wishlistService;
            _cityService = cityService;
        }

        public IActionResult List(string keyword, string location)
        {
            ViewBag.SearchModel = new MainSearchModel()
            {
                Keyword = keyword,
                Location = location
            };
            base.LoadViewBagDefaultData(_systemSetupService);
            base.GetPageMetaTags(_seoService, SeoPage.Project);
            ViewBag.City = new SelectList(_cityService.List().Where(m => m.Status).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult ListAjax(ProjectMainFilterModel projectMainFilterModel)
        {
            var projects = _projectService.ListByFilter(projectMainFilterModel);

            var uid = base.getUidFromClaim();
            if (uid != null)
            {
                var wishlist = _wishlistService.List(uid.ToString(), false);
                if (wishlist.Count > 0)
                {
                    foreach (var item in projects.List)
                    {
                        if (wishlist.Any(m => m.ProjectId == item.Id))
                        {
                            item.IsWishlist = true;
                        }
                    }
                }
            }

            return View("/Views/Projects/_ListAjax.cshtml", projects);
        }


        public IActionResult Single(int id, string name)
        {
            var project = _projectService.ById(id);
            project.ViewCount = project.ViewCount + 1;
            _projectService.Update(project);

            ViewBag.RelatedProjects = _projectService.GetRelatedProjects(project);
            base.LoadViewBagDefaultData(_systemSetupService);

            var user = _userManager.Users.FirstOrDefault(m => m.Id == project.CreatedBy);
            ViewBag.User = user;

            ViewData["Title"] = project.Name;
            ViewData["MetaKeyword"] = project.MetaTag;
            ViewData["MetaDescription"] = project.MetaDescription;

            return View(project);
        }

    }
}