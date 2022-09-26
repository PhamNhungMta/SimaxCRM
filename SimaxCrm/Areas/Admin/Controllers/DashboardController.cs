using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimaxCrm.Helper;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class DashboardController : BaseAdminController
    {
        private readonly ILeadService _leadService;
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _productService;
        private readonly ICallLogService _callLogService;
        private readonly ICallLogProductService _callLogProductService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMessageDetailService _messageDetailService;
        private readonly IHelperService _helperService;

        public DashboardController(
            ILeadService leadService,
            IInvoiceService invoiceService,
            IProductService productService,
            ICallLogService callLogService,
            ICallLogProductService callLogProductService,
            UserManager<ApplicationUser> userManager,
            IMessageDetailService messageDetailService,
            IHelperService helperService
            )
        {
            _leadService = leadService;
            _invoiceService = invoiceService;
            _productService = productService;
            _callLogService = callLogService;
            _callLogProductService = callLogProductService;
            _userManager = userManager;
            _messageDetailService = messageDetailService;
            _helperService = helperService;
        }


        public IActionResult Index()
        {
            var uid = base.getUidFromClaim();
            List<Lead> leads = null;
            List<Product> products = null;

            var dashboardBoxesModel = new DashboardBoxesModel();

            var filteredUsers = base.getAgentList(_userManager);
            var uids = filteredUsers.Select(m => m.Id).ToList();

            if (this.Request.UserIsRole(UserType.Admin) )
            {
                leads = _leadService.AllLeads();
                products = _productService.List();
            }
            else
            {
                leads = _leadService.ByUserIds(uids, null, null, "");
                products = _productService.ByLeadStatusAndUserId(null, uids, null);
            }

            var leadIds = leads.Select(m => m.Id).ToList();
            var productIds = products.Select(m => m.Id).ToList();

            var invoices = _invoiceService.ByLeadIds(leadIds);

            var salesChartData = getSalesChartData(invoices, 6);
            var leadsChartData = getLeadsChartData(leads);
            var productChartData = getProductChartData(products);

          


            var leadFollowUp = _leadService.GetFollowUpByLeadIds(leadIds);
            var productFollowUp = _productService.GetFollowUpByProductIds(productIds);

            var postpone = leads.Where(m => m.LeadStatus == LeadStatusType.Postpone.ToString()).ToList();

            List<CalenderResponse> calenderFollowUp = getFollowUpDataForCalender(leadFollowUp, productFollowUp);
            List<CalenderResponse> calenderPostpone = getPostponeForCalender(postpone);

            var currDate = DateTime.Now.Date;

            dashboardBoxesModel = new DashboardBoxesModel()
            {
                NewLead = leads.Count(m => m.LeadStatus == LeadStatusType.NewLead.ToString()),
                Postpone = postpone.Count(),
                Converted = leads.Count(m => m.LeadStatus == LeadStatusType.Converted.ToString()),
                FollowUp = leads.Count(m => m.LeadStatus == LeadStatusType.FollowUp.ToString() && m.AlertDate.Value.Date != null && m.AlertDate.Value.Date == currDate),
                MissedFollowUp = leads.Count(m => m.LeadStatus == LeadStatusType.FollowUp.ToString() && m.AlertDate.Value.Date != null && m.AlertDate.Value.Date < currDate),
                AllFollowUp = leads.Count(m => m.LeadStatus == LeadStatusType.FollowUp.ToString() && m.AlertDate.Value.Date != null),
                Closed = leads.Count(m => m.LeadStatus == LeadStatusType.Closed.ToString()),
                Reopen = leads.Count(m => m.LeadStatus == LeadStatusType.Reopen.ToString()),
                Surrender = leads.Count(m => m.LeadStatus == LeadStatusType.Surrender.ToString()),
                AllLead = leads.Count(),
                TotalProducts = products.Count(),
                ProductFollowUp = products.Where(m => m.Status == ProductStatusType.FollowUp.ToString() && m.AlertDate.Value.Date != null && m.AlertDate.Value.Date == currDate).Count(),
                ProductMissedFollowUp = products.Where(m => m.Status == ProductStatusType.FollowUp.ToString() && m.AlertDate.Value.Date != null && m.AlertDate.Value.Date < currDate).Count(),
                ProductMyFollowUp = products.Where(m => m.Status == ProductStatusType.FollowUp.ToString() && m.AlertDate.Value.Date != null).Count(),
                ProductSoldout = products.Where(m => m.Status == ProductStatusType.Soldout.ToString()).Count(),

                //InvoicePending = invoices.Count(m => m.OrderStatus == OrderStatusType.Pending),
                //InvoiceApproved = invoices.Count(m => m.OrderStatus == OrderStatusType.Approved),
                //InvoiceRejected = invoices.Count(m => m.OrderStatus == OrderStatusType.Rejected),
                SalesChart = null,// salesChartData,
                LeadsChart = leadsChartData,
                ProductChart = productChartData,
                CalenderFollowUp = calenderFollowUp,
                CalenderPostpone = calenderPostpone,
            };

            return View(dashboardBoxesModel);
        }

        private DashboardChartResponseModel getProductChartData(List<Product> products)
        {
            var toDate = DateTime.Now.Date;
            var fromDate = DateTime.Now.AddDays(-30).Date;

            var query = from m in products
                            //where m.CreatedDate.Date >= fromDate && m.CreatedDate.Date <= toDate
                        group m by m.Status into gg
                        select new
                        {
                            LeadStatus = gg.Key ?? "NoStatus",
                            Value = gg.Count()
                        };

            var queryData = query.ToList();

            return new DashboardChartResponseModel
            {
                Label = queryData.Select(m => m.LeadStatus).ToArray(),
                Data = queryData.Select(m => m.Value).ToArray()
            };
        }

        private List<CalenderResponse> getPostponeForCalender(List<Lead> postpone)
        {
            return (from m in postpone
                    select new CalenderResponse
                    {
                        id = m.IdStr,
                        title = "Lead Postpone. Id: " + m.IdStr,
                        start = m.AlertDate.Value.ToString("yyyy/MM/dd hh:mm"),
                        allDay = false,
                        className = "info"
                    })
                .ToList();
        }

        private static List<CalenderResponse> getFollowUpDataForCalender(List<Lead> leadFollowUp, List<Product> productFollowUp)
        {
            return (from m in leadFollowUp
                    select new CalenderResponse
                    {
                        id = m.IdStr,
                        title = $"Name: {m.Name}, " +
                        $"Message: { m.CallLog?.OrderByDescending(m => m.Id)?.FirstOrDefault()?.Message }, " +
                        $"Remarks: { m.CallLog?.OrderByDescending(m => m.Id)?.FirstOrDefault()?.Remarks }, " +
                        $"LeadType: { m.LeadType }, " +
                        $"UserName: {m.User?.Name}",
                        start = m.AlertDate.Value.ToString("yyyy/MM/dd hh:mm"),
                        allDay = false,
                        className = "info"
                    })
                .ToList()
                .Union((from m in productFollowUp
                        select new CalenderResponse
                        {
                            id = m.IdStr,
                            title = $"Name: {m.Name}, " +
                            $"Inventory Id: {m.IdStr }, " +
                            $"Message: { m.CallLogProduct?.OrderByDescending(m => m.Id)?.FirstOrDefault()?.Message }, " +
                            $"Remarks: { m.CallLogProduct?.OrderByDescending(m => m.Id)?.FirstOrDefault()?.Remarks }, " +
                            $"UserName: {m.UserStr}",
                            start = m.AlertDate.Value.ToString("yyyy/MM/dd hh:mm"),
                            allDay = false,
                            className = "success"
                        }).ToList()).ToList();
        }

        [HttpGet]
        public JsonResult GetFollowUp()
        {
            var userId = base.getUidFromClaim();
            var final = _helperService.GetNotifications(userId.ToString());

            var checkUser = _userManager.FindByIdAsync(userId.ToString()).Result;
            final.isUserActive = checkUser.IsActiveMarge;
            return Json(final);
        }

        [HttpPost]
        public JsonResult DeleteFollowUp(Dictionary<string, string> data)
        {
            var uid = base.getUidFromClaim();
            var id = int.Parse(data["id"]);
            var type = data["type"];

            if (type == "Lead")
            {
                var obj = _callLogService.ById(id);
                obj.AlertStatus = AlertStatusType.Deleted;
                _callLogService.Update(obj);
            }
            else if (type == "Message")
            {
                var obj = _messageDetailService.ByMessageIdAndUserId(id, uid.ToString());
                obj.AlertStatus = AlertStatusType.Deleted;
                _messageDetailService.Update(obj);
            }
            else
            {
                var obj = _callLogProductService.ById(id);
                obj.AlertStatus = AlertStatusType.Deleted;
                _callLogProductService.Update(obj);
            }

            return Json(new BaseResponse<string> { Success = true });
        }

        private DashboardChartResponseModel getSalesChartData(List<Invoice> invoices, int lastMonths)
        {
            var tempfromDate = DateTime.Now.AddMonths(lastMonths * -1);
            var fromDate = new DateTime(tempfromDate.Year, tempfromDate.Month, 1);
            var toDate = DateTime.Now;
            var lastSixMonths = Enumerable.Range(0, lastMonths)
                              .Select(i => DateTime.Now.AddMonths((i + 1) - lastMonths))
                              .Select(date => date.ToString("MMM"));

            var saleBillData = invoices.Where(m => m.OrderStatus == OrderStatusType.Approved && m.CreatedDate.Date >= fromDate && m.CreatedDate.Date <= toDate).ToList();
            var query = from m in lastSixMonths
                        join s in saleBillData on m equals s.CreatedDate.ToString("MMM") into ss
                        from s in ss.DefaultIfEmpty()
                        group new { m, s } by m into gg
                        select new
                        {
                            Month = gg.Key,
                            Value = gg.Sum(x => x.s?.GrandTotal)
                        };

            var queryData = query.ToList();

            return new DashboardChartResponseModel
            {
                Label = queryData.Select(m => m.Month).ToArray(),
                Data = queryData.Select(m => Convert.ToInt32(m.Value == null ? 0 : m.Value)).ToArray()
            };
        }

        private DashboardChartResponseModel getLeadsChartData(List<Lead> leads)
        {
            var toDate = DateTime.Now.Date;
            var fromDate = DateTime.Now.AddDays(-30).Date;

            var query = from m in leads
                        where m.AssignedDate.Date >= fromDate && m.AssignedDate.Date <= toDate
                        group m by m.LeadStatus into gg
                        select new
                        {
                            LeadStatus = gg.Key,
                            Value = gg.Count()
                        };

            var queryData = query.ToList();

            return new DashboardChartResponseModel
            {
                Label = queryData.Select(m => m.LeadStatus).ToArray(),
                Data = queryData.Select(m => m.Value).ToArray()
            };
        }

    }

}