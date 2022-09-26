using Microsoft.AspNetCore.Mvc;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System;
using SimaxCrm.Helper;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class CallLogProductController : BaseAdminController
    {
        private readonly ICallLogProductService _callLogService;
        private readonly ILeadService _leadService;
        private readonly IProductService _productService;

        public CallLogProductController(ICallLogProductService callLogService,
            ILeadService leadService,
            IProductService productService)
        {
            _callLogService = callLogService;
            _leadService = leadService;
            _productService = productService;
        }

        [HttpPost]
        public JsonResult Update(CallLogProduct callLog)
        {
            var result = new BaseResponse<string>();
            var uid = (Guid)base.getUidFromClaim();

            if (callLog.Id == 0)
            {
                callLog.CreatedDate = DateTime.Now;
                callLog.UserId = uid.ToString();
                _callLogService.Create(callLog);
            }


            var lead = _productService.ById(callLog.ProductId);
            if (callLog.Status != LeadStatusType.Comment.ToString())
                lead.Status = callLog.Status;
            if (callLog.AlertDate.HasValue)
                lead.AlertDate = callLog.AlertDate;

            _productService.Update(lead);

            result.Success = true;
            return Json(result);
        }
    }
}
