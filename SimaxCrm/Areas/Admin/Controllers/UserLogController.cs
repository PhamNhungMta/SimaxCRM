using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using SimaxCrm.Helper;
using System.Linq;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class UserLogController : BaseAdminController
    {
        private readonly IUserLogService _userLogService;
        private readonly IHelperService _helperService;
        private readonly ILeadService _leadService;
        private readonly IEmailSetupService _emailSetupService;

        public UserLogController(IUserLogService userLogService,
            IHelperService helperService,
            ILeadService leadService,
            IEmailSetupService emailSetupService)
        {
            _userLogService = userLogService;
            _helperService = helperService;
            _leadService = leadService;
            _emailSetupService = emailSetupService;
        }

        [HttpPost]
        public JsonResult SendText(SendTextModel sendTextModel)
        {
            var result = new BaseResponse<string>();
            var uid = (Guid)base.getUidFromClaim();

            var lead = _leadService.ById(sendTextModel.LeadId);
            var emailSetup = _emailSetupService.List().Where(m => m.Status).FirstOrDefault();

            string sendTextResult = "";
            var isSent = _helperService.SendText(sendTextModel, lead, emailSetup, ref sendTextResult);

            var userLog = new UserLog()
            {
                CreatedDate = DateTime.Now,
                IsSuccess = isSent,
                LogStatus = sendTextResult,
                UserId = uid.ToString(),
                LeadId = sendTextModel.LeadId,
                LogRecId = sendTextModel.LogRecId,
                LogText = sendTextModel.LogText,
                LogType = sendTextModel.LogType.ToString(),
            };
            _userLogService.Create(userLog);
            result.Success = isSent;
            result.Response = sendTextResult;
            return Json(result);
        }
    }
}