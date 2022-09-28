using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class ContentHomepageController : BaseAdminController
    {
        private readonly IContentHomepageService _ContentHomepageService;

        public ContentHomepageController (IContentHomepageService ContentHomepageService) 
        {
            _ContentHomepageService = ContentHomepageService;
        }

        [HttpGet]
        public IActionResult Homepage()
        {
            var uid = base.getUidFromClaim().ToString();
            var homepage = _ContentHomepageService.GetHomepageByAgentId(uid);
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

            if (id == 0)
            {
                obj.CreatedDate = DateTime.Now;
                _ContentHomepageService.Create(obj);
            }   
            else
            {
                obj.UpdatedDate = DateTime.Now;
                _ContentHomepageService.Update(obj);
            }
            
            ViewBag.Result = "Update Homepage Successfully";
            
            return View();
        }
    }
}