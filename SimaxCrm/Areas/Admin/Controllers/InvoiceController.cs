using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using SimaxCrm.Helper;
using System.Threading.Tasks;

namespace SimaxCrm.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class InvoiceController : BaseAdminController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ISystemSetupService _systemSetupService;
        private readonly IProductService _productService;
        private readonly ILeadService _leadService;
        private readonly ICallLogService _callLogService;

        public InvoiceController(IInvoiceService invoiceService,
            ISystemSetupService systemSetupService,
            IProductService productService,
            ILeadService leadService,
            ICallLogService callLogService)
        {
            _invoiceService = invoiceService;
            _systemSetupService = systemSetupService;
            _productService = productService;
            _leadService = leadService;
            _callLogService = callLogService;
        }

        public IActionResult Index(int leadId, string orderStatus)
        {
            return View(_invoiceService.ListByLeadIdAndOrderStatus(leadId, orderStatus));
        }

        public IActionResult Create(int id, int leadId)
        {
            ViewBag.SystemSetup = _systemSetupService.List().Where(m => m.Status).FirstOrDefault();
            ViewBag.Lead = _leadService.ById(leadId);
            var invoice = new Invoice();
            if (id > 0)
            {
                invoice = _invoiceService.ById(id);
                invoice.InvoiceDetailJson = JsonConvert.SerializeObject(invoice.InvoiceDetail, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                ViewBag.CallLog = _callLogService.ByInvoiceId(id).OrderByDescending(m => m.Id).ToList();
            }
            return View(invoice);
        }


        [HttpPost]
        public JsonResult Create(Invoice orderModel)
        {
            var result = new BaseResponse<Invoice>();
            if (orderModel.Id == 0)
            {
                result = _invoiceService.Create(orderModel);
            }
            else
            {
                result = _invoiceService.Update(orderModel);
            }
            return Json(result);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var obj = _invoiceService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Invoice obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obj.UpdatedDate = DateTime.Now;
                _invoiceService.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // GET: ServiceType/Delete/5
        public IActionResult Delete(int id)
        {
            var obj = _invoiceService.ById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: ServiceType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Dictionary<string, string> data)
        {
            int id = int.Parse(data["Id"].ToString());
            string returnUrl = data["RetrunUrl"].ToString();
            _invoiceService.Delete(id);
            return Redirect(returnUrl);
        }

        [HttpGet]
        public JsonResult AllProducts()
        {
            var obj = _productService.List();
            return Json(obj);
        }

        [HttpPost]
        public JsonResult UpdateInvoiceStatus(Dictionary<string, string> data)
        {
            var userId = base.getUidFromClaim();

            Enum.TryParse(data["status"], out OrderStatusType status);
            var id = int.Parse(data["id"]);
            var leadId = int.Parse(data["leadId"]);
            var remarks = data["remarks"];

            var invoice = _invoiceService.ById(id);
            invoice.OrderStatus = status;
            _invoiceService.UpdateOnly(invoice);

            var callLog = new CallLog()
            {
                Id = 0,
                AlertDate = null,
                CreatedDate = DateTime.Now,
                EndTime = DateTime.Now.TimeOfDay,
                StartTime = DateTime.Now.TimeOfDay,
                LeadId = leadId,
                InvoiceId = id,
                Status = "Invoice",
                Remarks = status.ToString(),
                Message = remarks,
                UserId = userId.Value.ToString()
            };
            _callLogService.Create(callLog);
            return Json(new BaseResponse<string>() { Success = true });
        }
    }
}
