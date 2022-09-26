using Microsoft.AspNetCore.Identity;
using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimaxCrm.Service.Implementation
{
    public class ProcessJobService : IProcessJobService
    {
        private readonly ILeadService _leadService;
        private readonly IProductService _productService;
        private readonly IHelperService _helperService;
        private readonly ICallLogService _callLogService;
        private readonly ICallLogProductService _callLogProductService;

        public ProcessJobService(
            ILeadService leadService,
            IHelperService helperService,
            IProductService productService,
            ICallLogService callLogService,
            ICallLogProductService callLogProductService
            )
        {
            _leadService = leadService;
            _helperService = helperService;
            _productService = productService;
            _callLogService = callLogService;
            _callLogProductService = callLogProductService;
        }

        public void PushFollowUpNotifications()
        {

            var callLogs = _callLogService.GetAllOldActiveReminder();
            foreach (var item in callLogs)
            {
                if (item.Status == "FollowUp")
                {
                    _helperService.PostToFirebase("Lead Follow Up", $"Lead Id: {item.LeadId}, Follow Up: {item.AlertDate.ToString()}", item.UserId, "");
                }
                else if (item.Status == "Lead" && item.Remarks == "New Lead")
                {
                    _helperService.PostToFirebase("New Lead", $"Lead Id: {item.LeadId}", item.UserId, "");
                }
                item.AlertStatusFcm = AlertStatusType.Shown;
                _callLogService.Update(item);
            }


            var callLogProducts = _callLogProductService.GetAllOldActiveReminder();
            foreach (var item in callLogProducts)
            {
                _helperService.PostToFirebase("Inventory Follow Up", $"Inventory Id: {item.ProductId}, Follow Up: {item.AlertDate.ToString()}", item.UserId, "");
                item.AlertStatusFcm = AlertStatusType.Shown;
                _callLogProductService.Update(item);
            }
        }
    }
}
