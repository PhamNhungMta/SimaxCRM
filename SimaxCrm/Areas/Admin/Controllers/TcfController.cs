using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Data.Context;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [Authorize]
    public class TcfController : Controller
    {
        private readonly ITcfService _tcfService;

        public TcfController(ITcfService tcfService)
        {
            _tcfService = tcfService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_tcfService.List());
        }
    }
}
