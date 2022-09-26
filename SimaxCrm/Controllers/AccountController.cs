using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using SimaxShop.Service.Interface;

namespace SimaxCrm.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ISeoService _seoService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAccountService _accountService;
        private readonly IOtpLogService _otpLogService;
        private readonly IHelperService _helperService;
        private readonly ISystemSetupService _systemSetupService;


        public AccountController(IAccountService accountService,
            ISystemSetupService systemSetupService,
            UserManager<ApplicationUser> userManager,
            IOtpLogService otpLogService,
            IHelperService helperService,
            ISeoService seoService)
        {
            _seoService = seoService;
            _userManager = userManager;
            _accountService = accountService;
            _helperService = helperService;
            _systemSetupService = systemSetupService;
            _otpLogService = otpLogService;
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            base.LoadViewBagDefaultData(_systemSetupService);
            base.GetPageMetaTags(_seoService, SeoPage.Login);
            
            string[] validRoles = { UserType.Admin.ToString() };
            ViewBag.IsAdminUser = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                   .Where(m => m.UserRoles.Any(m => validRoles.Contains(m.Role.Name))).Any();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            var response = await _accountService.Login(userLoginModel);
            if (response.Success)
            {
                Response.Cookies.Append(
                     "UserToken", response.Response,
                     new Microsoft.AspNetCore.Http.CookieOptions()
                     {
                         Path = "/"
                     }
                 );
                if (string.IsNullOrEmpty(userLoginModel.ReturnUrl))
                {
                    return LocalRedirect("/Home");
                }
                else
                {
                    return LocalRedirect(userLoginModel.ReturnUrl);
                }
            }
            else
            {
                ModelState.AddModelError("", response.Response);
            }
            base.LoadViewBagDefaultData(_systemSetupService);
            base.GetPageMetaTags(_seoService, SeoPage.Login);
            return View();
        }

        public IActionResult Register(string returnUrl, string type)
        {
            base.LoadViewBagDefaultData(_systemSetupService);
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.UserLoginType = (type == "Admin" ? UserType.Admin : UserType.Customer);

            base.GetPageMetaTags(_seoService, SeoPage.Register);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel)
        {
            var response = await _accountService.Register(userRegisterModel);
            if (response.Success)
            {
                if (userRegisterModel.UserType == UserType.Admin)
                {
                    _helperService.createDefaultData(userRegisterModel.Tid);
                }

                Response.Cookies.Append(
                     "UserToken", response.Response,
                     new Microsoft.AspNetCore.Http.CookieOptions()
                     {
                         Path = "/"
                     }
                 );

                if (string.IsNullOrEmpty(userRegisterModel.ReturnUrl))
                {
                    return LocalRedirect("/Home");
                }
                else
                {
                    return LocalRedirect(userRegisterModel.ReturnUrl);
                }
            }
            else
            {
                ModelState.AddModelError("", response.Response);
            }
            base.LoadViewBagDefaultData(_systemSetupService);
            base.GetPageMetaTags(_seoService, SeoPage.Register);
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            if (Request.Cookies["UserToken"] != null)
            {
                Response.Cookies.Delete("UserToken");
            }

            return LocalRedirect("/Home");
        }

    }
}