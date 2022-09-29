using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using SimaxCrm.Model.Enum;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class ContentHomepageController : BaseAdminController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IContentHomepageService _contentHomepageService;

        public ContentHomepageController ( UserManager<ApplicationUser> userManager,
            IContentHomepageService contentHomepageService) 
        {
            _userManager = userManager;
            _contentHomepageService = contentHomepageService;
        }

        [HttpGet]
        public IActionResult Homepage()
        {
            var uid = base.getUidFromClaim().ToString();
            var user = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Where(m => m.Id == uid).FirstOrDefault();
            var role = user.UserRoles.FirstOrDefault()?.Role?.Name;
            var homepage = _contentHomepageService.GetHomepageByAgentId(uid);
            if (role.Equals(UserType.CompanyAdmin.ToString()))
            {
                homepage = _contentHomepageService.GetHomepageByCompanyId(user.CompanyId);
            } else if (role.Equals(UserType.BranchAdmin.ToString()))
            {
                homepage = _contentHomepageService.GetHomepageByBranchId(user.BranchId);
            }
            return View(homepage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Homepage(int id, ContentHomepage obj)
        {
            var uid = base.getUidFromClaim().ToString();

            obj.Id = id;
            obj.Tid = 0;
            obj.AgentId = uid;

            var user = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Where(m => m.Id == uid).FirstOrDefault();
            var role = user.UserRoles.FirstOrDefault()?.Role?.Name;

            if (role.Equals(UserType.CompanyAdmin.ToString()))
            {
                obj.CompanyId = user.CompanyId;
            } else if (role.Equals(UserType.BranchAdmin.ToString()))
            {
                obj.BranchId = user.BranchId;
            }
            if (id == 0)
            {
                obj.CreatedDate = DateTime.Now;
                _contentHomepageService.Create(obj);
            }   
            else
            {
                obj.UpdatedDate = DateTime.Now;
                _contentHomepageService.Update(obj);
            }
            
            ViewBag.Result = "Update Homepage Successfully";
            
            return View();
        }
    }
}