using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SimaxBilling.Model.Enum;
using Microsoft.AspNetCore.Authorization;
using SimaxCrm.Helper;
using SimaxCrm.Service.Interface;
using SimaxCrm.Model.RequestModel;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SimaxCrm.Model.Entity;
using System.Linq;
using NuGet.Frameworks;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Model.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class ReportController : BaseAdminController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IReportService _reportService;
        private readonly ILeadService _leadService;
        private readonly ILeadSourceService _leadSourceService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportController(
            IWebHostEnvironment webHostEnvironment,
            IReportService reportService,
            ILeadService leadService,
            UserManager<ApplicationUser> userManager,
            ILeadSourceService leadSourceService)
        {
            _webHostEnvironment = webHostEnvironment;
            _reportService = reportService;
            _leadService = leadService;
            _userManager = userManager;
            _leadSourceService = leadSourceService;
        }

        [HttpGet]
        public JsonResult InvoicePreview(int id, ReportFormType reportFormType, ReportType reportType)
        {
            var result = _reportService.GetBillInvoice(id, _webHostEnvironment.ContentRootPath, reportFormType, ReportType.pdf);
            return Json(result);
        }

        [HttpGet]
        public FileResult InvoiceDownload(int id, ReportFormType reportFormType, ReportType reportType)
        {
            var result = _reportService.GetBillInvoiceBytes(id, _webHostEnvironment.ContentRootPath, reportFormType, reportType);
            var content = new System.IO.MemoryStream(result);
            var contentType = "APPLICATION/octet-stream";
            var fileName = reportFormType.ToString() + "." + reportType;
            return File(content, contentType, fileName);
        }

        public IActionResult LeadSummary()
        {
            ViewBag.AllLead = new LeadSummaryReportModel()
            {
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                UserId = ""
            };

            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");

            return View(new List<LeadSummaryReportResponse>());
        }


        [HttpPost]
        public IActionResult LeadSummary(LeadSummaryReportModel model)
        {
            var uids = new List<string>();
            if (this.Request.UserIsRole(Model.Enum.UserType.Admin))
            {
                uids = null;
            }
            else
            {
                var filteredUsers = base.getAgentList(_userManager);
                uids = filteredUsers.Select(m => m.Id).ToList();
            }

            if (!string.IsNullOrEmpty(model.UserId))
            {
                uids = new List<string>();
                uids.Add(Guid.Parse(model.UserId).ToString());
            }

            var data = _leadService.ByLeadSummaryReportModel(model, uids);

            var query = from q in data
                        group q by new { q.UserId } into gg
                        select new LeadSummaryReportResponse
                        {
                            UserId = gg.Key.UserId,
                            UserName = gg.Max(m => m.User?.Name),
                            CallLog = gg.Max(m => (m.PhoneCallLeadLog?.Count ?? 0)),
                            SiteVisit = gg.Max(m => m.CallLog?.Select(x => new { x.Remarks, x.LeadId })?.Distinct()?.Count(x => x.Remarks == "Site Visit Done") ?? 0),
                            Closed = gg.Count(m => m.LeadStatus == LeadStatusType.Closed.ToString()),
                            Converted = gg.Count(m => m.LeadStatus == LeadStatusType.Converted.ToString()),
                            FollowUp = gg.Count(m => m.LeadStatus == LeadStatusType.FollowUp.ToString()),
                            NewLead = gg.Count(m => m.LeadStatus == LeadStatusType.NewLead.ToString()),
                            Postpone = gg.Count(m => m.LeadStatus == LeadStatusType.Postpone.ToString()),
                            Reopen = gg.Count(m => m.LeadStatus == LeadStatusType.Reopen.ToString()),
                            Surrender = gg.Count(m => m.LeadStatus == LeadStatusType.Surrender.ToString()),
                            Hot = gg.Count(m => m.LeadTagMapping.Any(x => x.LeadTag.Name == "Hot")),
                            All = gg.Count(),
                            UserTime = formatTime(gg.Max(m => m.CallLog?.Sum(x => x.DifferenceInSeconds) ?? 0)),
                        };

            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");


            ViewBag.AllLead = model;

            return View(query.ToList());
        }


        public IActionResult LeadSummarySourceWise()
        {
            ViewBag.AllLead = new LeadSummaryReportModel()
            {
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.Date,
                UserId = ""
            };

            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");

            ViewBag.Sources = _leadSourceService.List().Where(m => m.Status).ToList();
            ViewBag.Users = new List<string>();


            return View(new List<LeadSummaryReportResponse>());
        }


        [HttpPost]
        public IActionResult LeadSummarySourceWise(LeadSummaryReportModel model)
        {
            var uids = new List<string>();
            if (this.Request.UserIsRole(Model.Enum.UserType.Admin) )
            {
                uids = null;
            }
            else
            {
                var filteredUsers = base.getAgentList(_userManager);
                uids = filteredUsers.Select(m => m.Id).ToList();
            }

            if (!string.IsNullOrEmpty(model.UserId))
            {
                uids = new List<string>();
                uids.Add(Guid.Parse(model.UserId).ToString());
            }

            var data = _leadService.ByLeadSummaryReportModel(model, uids);

            var query = from q in data
                        group q by new { q.UserId, q.LeadSource.Name } into gg
                        select new LeadSummaryReportResponse
                        {
                            UserId = gg.Key.UserId,
                            UserName = gg.Max(m => m.User?.Name),
                            LeadSourceName = gg.Key.Name,
                            All = gg.Count(),
                        };

            var dataAll = query.ToList();

            ViewBag.UserId = new SelectList(base.getUsersForLeadAssignList(_userManager), "Id", "Name");
            ViewBag.Sources = _leadSourceService.List().Where(m => m.Status).ToList();
            ViewBag.Users = dataAll.Select(m=>m.UserName).Distinct().ToList();

            ViewBag.AllLead = model;

            return View(dataAll);
        }



        private static string formatTime(double secs)
        {
            int hours = Convert.ToInt32(secs / 3600);
            int mins = Convert.ToInt32((secs % 3600) / 60);
            secs = secs % 60;
            return $"{hours.ToString("00")}:{mins.ToString("00")}:{secs.ToString("00")}";
        }
    }

}

