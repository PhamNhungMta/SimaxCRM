using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Controllers
{
    public class AgentsController : BaseController
    {
        private readonly ISystemSetupService _systemSetupService;
        private readonly ISeoService _seoService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductService _productService;
        private readonly ICustomerQueryService _customerQueryService;
        private readonly IUserRatingService _userRatingService;

        public AgentsController(UserManager<ApplicationUser> userManager,
            IProductService productService,
            IUserRatingService userRatingService,
            ICustomerQueryService customerQueryService,
            ISystemSetupService systemSetupService,
            ISeoService seoService
            )
        {
            _systemSetupService = systemSetupService;
            _seoService = seoService;
            _userManager = userManager;
            _productService = productService;
            _customerQueryService = customerQueryService;
            _userRatingService = userRatingService;
        }

        public IActionResult List()
        {
            base.LoadViewBagDefaultData(_systemSetupService);
            ViewBag.SearchModel = new AgentFilterModel();
            ViewBag.TopRatedAgents = _userRatingService.ListTopUserRatings(hasTid: false);
            base.GetPageMetaTags(_seoService, SeoPage.Agents);
            return View();
        }

        [HttpPost]
        public IActionResult ListAjax(AgentFilterModel model)
        {
            var userResponse = listAgents(model);
            var products = _productService.ListByUserIds(userResponse.List.Select(m => m.Id).ToList());
            var returnObj = new ListResponseModel<ApplicationUser, Product>()
            {
                CurrentPage = userResponse.CurrentPage,
                List = userResponse.List,
                ListHelper = products,
                SortBy = userResponse.SortBy,
                Take = userResponse.Take,
                TotalItems = userResponse.TotalItems,
                TotalPages = userResponse.TotalPages,
            };
            return View("/Views/Agents/_ListAjax.cshtml", returnObj);
        }

       
        private ListResponseModel<ApplicationUser> listAgents(AgentFilterModel filterModel)
        {
            var responseModel = new ListResponseModel<ApplicationUser>();
            string[] validRoles = { UserType.Agent.ToString() };
            var user = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                   .Where(m => m.UserRoles.Any(m => validRoles.Contains(m.Role.Name)));


            if (!string.IsNullOrEmpty(filterModel.Keyword))
            {
                user = user.Where(m => m.Name.Contains(filterModel.Keyword));
            }

            if (!string.IsNullOrEmpty(filterModel.Company))
            {
                user = user.Where(m => m.CompanyName.Contains(filterModel.Company));
            }

            if (!string.IsNullOrEmpty(filterModel.City))
            {
                user = user.Where(m => m.City.Contains(filterModel.City));
            }

            if (filterModel.PremiumCertified > 0)
            {
                user = user.Where(m => m.UserRank.Equals(filterModel.PremiumCertified));
            }

            int skip = (filterModel.CurrentPage - 1) * filterModel.Take;
            responseModel.SortBy = (int)filterModel.SortBy;
            responseModel.Take = filterModel.Take;
            responseModel.TotalItems = user.Count();
            responseModel.CurrentPage = filterModel.CurrentPage;
            responseModel.TotalPages = Math.Ceiling((decimal)responseModel.TotalItems / filterModel.Take);
            responseModel.List = user.Skip(skip).Take(filterModel.Take).ToList();
            return responseModel;
        }

        [MainCustomAuthorize]
        public IActionResult Single(string id)
        {
            var user = _userManager.Users.Where(m => m.Id == id).FirstOrDefault();
            ViewBag.Products = _productService.ListByUserIdAll(user.Id);
            ViewBag.CustomerQueries = _customerQueryService.ByAgentIdForProperty(user.Id);
            ViewBag.Ratings = _userRatingService.ByUserId(user.Id, hasTid: false);
            base.LoadViewBagDefaultData(_systemSetupService);

            ViewData["Title"] = user.Name;
            ViewData["MetaKeyword"] = user.Name;
            ViewData["MetaDescription"] = user.Name;

            return View(user);
        }
    }
}