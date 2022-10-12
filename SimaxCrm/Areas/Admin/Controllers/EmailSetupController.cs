using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Helper;
using SimaxCrm.Service.Interface;
using System;
using SimaxCrm.Model.Enum;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimaxCrm.Model.RequestModel;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class EmailSetupController : BaseAdminController
    {
        private readonly IEmailSetupService _emailSetupService;
        private readonly IHelperService _helperService;
        private readonly IEmailService _emailService;
        private readonly IEmailSentService _emailSentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmailSetupController(IEmailSetupService emailSetupService,
            IHelperService helperService,
            IEmailService emailService,
            IEmailSentService emailSentService,
            UserManager<ApplicationUser> userManager)
        {
            _emailSetupService = emailSetupService;
            _helperService = helperService;
            _emailService = emailService;
            _emailSentService = emailSentService;
            _userManager = userManager;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            var uid = base.getUidFromClaim().ToString();
            var user = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                            .Where(u => u.Id == uid).FirstOrDefault();
            var role = user.UserRoles.FirstOrDefault()?.Role?.Name;

            List<EmailSetup> emailSetups = _emailSetupService.List();
            if (user.Permissions != null)
            {
                var permissions = JsonConvert.DeserializeObject<Permissions>(user.Permissions);
                if (permissions.InventoryPermissions.Contains("view-own") && !permissions.InventoryPermissions.Contains("all"))
                {
                    emailSetups = emailSetups.Where(m => m.CreatedBy == uid).ToList();
                }
            }
            if (role.Equals(UserType.CompanyAdmin.ToString()))
            {
                emailSetups = emailSetups.Where(p => p.CompanyId == user.CompanyId).ToList();
            }
            if (role.Equals(UserType.BranchAdmin.ToString()) || role.Equals(UserType.Employee.ToString()))
            {
                emailSetups = emailSetups.Where(p => p.BranchId == user.BranchId).ToList();
            }
            return View(emailSetups);
        }

        public IActionResult New()
        {
            var uid = base.getUidFromClaim().ToString();
            var emailSetupList = _emailSetupService.List().Where(m => m.CreatedBy == uid).ToList();
            ViewBag.Emails = new SelectList(emailSetupList.ToList(), "Email", "Email");
            return View();
        }

        [HttpPost]
        public IActionResult New(EmailSent obj)
        {
            var uid = base.getUidFromClaim().ToString();

            obj.CreatedDate = DateTime.Now;
            obj.Id = 0;
            obj.SendBy = uid;

            var emailSetup = _emailSetupService.List().FirstOrDefault(m => m.CreatedBy == uid && m.Email == obj.FromEmail);

            var isSent = _helperService.SendText(obj, emailSetup);
            obj.IsSent = isSent;
            _emailSentService.Create(obj);
            if (isSent)
                ViewBag.Result = "Email Sent Successfully";
            else
                ViewBag.ResultError = "Email not sent";

            var emailSetupList = _emailSetupService.List().Where(m => m.CreatedBy == uid).ToList();
            ViewBag.Emails = new SelectList(emailSetupList.ToList(), "Email", "Email");

            return View();
        }


        // GET: ServiceType/Create
        public IActionResult Inbox(int emailSetupId)
        {
            var uid = base.getUidFromClaim().ToString();
            ViewBag.EmailSetupId = emailSetupId;
            //ViewBag.Type = (int)type;
            var emailSetupList = _emailSetupService.List().Where(m => m.CreatedBy == uid).ToList();
            ViewBag.Emails = new SelectList(emailSetupList.ToList(), "Id", "Email");
            if (emailSetupId > 0)
            {
                var emailSetup = _emailSetupService.ById(emailSetupId);
                var messages = _emailService.GetMails(emailSetup, EmailBoxType.INBOX);
                foreach (var msg in messages)
                {
                    msg.ContentTransferEncoding = DateTime.Now.ToFileTime().ToString();
                }
                messages = messages.OrderByDescending(m => m.Date).ToList();
                return View(messages);
            }
            return View(new List<AE.Net.Mail.MailMessage>());
        }


        // GET: ServiceType/Create
        public IActionResult Sent()
        {
            var uid = base.getUidFromClaim().ToString();
            var list = _emailSentService.List().Where(m => m.SendBy == uid && m.IsSent).OrderByDescending(m => m.Id).ToList();
            return View(list);
        }

        public IActionResult ViewEmail(int emailSetupId, string emailId)
        {

            var emailSetup = _emailSetupService.ById(emailSetupId);
            var message = _emailService.GetInboxMailById(emailSetup, emailId);
            return View(message);
        }

        public IActionResult ViewSentEmail(int emailId)
        {
            var message = _emailSentService.ById(emailId);
            return View(message);
        }


        // GET: ServiceType/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmailSetup obj)
        {
            if (ModelState.IsValid)
            {
                var result = true;// 
                if (result)
                {
                    //obj.Status = true;
                    obj.CreatedBy = base.getUidFromClaim().ToString();
                    obj.CreatedDate = DateTime.Now;
                    var user = _userManager.Users.Where(u => u.Id == obj.CreatedBy).FirstOrDefault();
                    obj.CompanyId = user.CompanyId;
                    obj.BranchId = user.BranchId;
                    _emailSetupService.Create(obj);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //ModelState.AddModelError("SmtpServer", errorMsg);
                }
            }
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _emailSetupService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmailSetup obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //obj.Status = true;
                obj.CreatedBy = base.getUidFromClaim().ToString();
                obj.UpdatedDate = DateTime.Now;
                _emailSetupService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _emailSetupService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _emailSetupService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
