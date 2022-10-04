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
    public class CompanyController : BaseAdminController
    {
        private readonly ICompanyService _companyService;
        private readonly IBranchService _branchService;

        public CompanyController(ICompanyService companyService, IBranchService branchService)
        {
            _companyService = companyService;
            _branchService = branchService;
        }

        public IActionResult Index()
        {
            var list = _companyService.List();
            return View(_companyService.List());
        }

        public IActionResult Detail(string id)
        {
            var obj = _companyService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Branch(string id)
        {
            var obj = _branchService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

    }
}