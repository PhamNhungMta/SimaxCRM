using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using SimaxCrm.Helper;
using System.Linq;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class MessageController : BaseAdminController
    {
        private readonly IMessageService _messageService;
        private readonly IMessageDetailService _messageDetailService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHelperService _helperService;

        public MessageController(IMessageService messageService,
            UserManager<ApplicationUser> userManager,
            IMessageDetailService messageDetailService,
            IHelperService helperService)
        {
            _messageService = messageService;
            _userManager = userManager;
            _helperService = helperService;
            _messageDetailService = messageDetailService;
        }

        // GET: ServiceType
        public IActionResult Index()
        {
            return View(_messageService.List());
        }

        // GET: ServiceType/Create
        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(base.getAgentList(_userManager, true), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Message obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatedById = base.getUidFromClaim().ToString();
                obj.CreatedDate = DateTime.Now;
                _messageService.Create(obj);

                foreach (var user in obj.Users.Split(','))
                {
                    if (user == "All")
                    {
                        var allUsers = _userManager.Users.ToList().Where(m => m.IsActive).ToList();
                        foreach(var allUser in allUsers)
                        {
                            var detail = new MessageDetail()
                            {
                                Id = 0,
                                AlertStatus = Model.Enum.AlertStatusType.Pending,
                                MessageId = obj.Id,
                                SentToUserId = allUser.Id,
                            };
                            _messageDetailService.Create(detail);

                            _helperService.PostToFirebase(obj.Name, obj.Body, allUser.Id, "");
                        }
                    }
                    else
                    {
                        var detail = new MessageDetail()
                        {
                            Id = 0,
                            AlertStatus = Model.Enum.AlertStatusType.Pending,
                            MessageId = obj.Id,
                            SentToUserId = user,
                        };
                        _messageDetailService.Create(detail);

                        _helperService.PostToFirebase(obj.Name, obj.Body, user, "");
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            ViewBag.UserId = new SelectList(base.getAgentList(_userManager, true), "Id", "Name");
            return View(obj);
        }
    }
}
