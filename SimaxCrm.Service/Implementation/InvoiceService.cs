using Newtonsoft.Json;
using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.Enum;
using SimaxCrm.Model.ResponseModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        private readonly IProductService _productService;
        public InvoiceService(IInvoiceRepository invoiceRepository,
            IInvoiceDetailRepository invoiceDetailRepository,
            IProductService productService)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _productService = productService;
        }

        public void Delete(int id)
        {
            var obj = _invoiceRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            _invoiceRepository.Delete(obj);
        }

        public List<Invoice> List()
        {
            return _invoiceRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public Invoice ById(int id)
        {
            return _invoiceRepository.SearchFor(x => x.Id == id, "InvoiceDetail").FirstOrDefault();
        }

        public BaseResponse<Invoice> Create(Invoice invoice)
        {
            var validateOrderModalResult = validateOrderModal(invoice);
            if (!validateOrderModalResult.Success)
            {
                return validateOrderModalResult;
            }

            invoice.Id = 0;
            invoice.CreatedDate = DateTime.Now;
            invoice.OrderStatus = OrderStatusType.Pending;
            _invoiceRepository.Insert(invoice);

            var invoiceDetail = JsonConvert.DeserializeObject<List<InvoiceDetail>>(invoice.InvoiceDetailJson);
            foreach (var detail in invoiceDetail)
            {
                detail.Id = 0;
                detail.CreatedDate = DateTime.Now;
                detail.InvoiceId = invoice.Id;
                _invoiceDetailRepository.Insert(detail);

                
            }
            var invoiceData = _invoiceRepository.SearchFor(x => x.Id == invoice.Id, "InvoiceDetail").FirstOrDefault();
            return new BaseResponse<Invoice>() { Success = true, Data = invoiceData };
        }

        public void UpdateOnly(Invoice invoice)
        {
            _invoiceRepository.UpdateEntity(invoice);
        }

        public BaseResponse<Invoice> Update(Invoice invoice)
        {
            var validateOrderModalResult = validateOrderModal(invoice);
            if (!validateOrderModalResult.Success)
            {
                return validateOrderModalResult;
            }

            var existingSaleBill = _invoiceRepository.GetById(invoice.Id, false);
            if (existingSaleBill.OrderStatus == OrderStatusType.Approved)
            {
                return new BaseResponse<Invoice>() { Success = false, Response = "Cannot update approved invoice" };
            }
            invoice.CreatedDate = existingSaleBill.CreatedDate;
            invoice.UpdatedDate = DateTime.Now;
            invoice.OrderStatus = existingSaleBill.OrderStatus == OrderStatusType.Rejected ? OrderStatusType.Pending : existingSaleBill.OrderStatus;
            _invoiceRepository.UpdateEntity(invoice);

            var invoiceDetail = JsonConvert.DeserializeObject<List<InvoiceDetail>>(invoice.InvoiceDetailJson);
            foreach (var detail in invoiceDetail)
            {
                switch (detail.ActionType)
                {
                    case InvoiceDetailActionType.Insert:
                        detail.Id = 0;
                        detail.CreatedDate = DateTime.Now;
                        detail.InvoiceId = invoice.Id;
                        _invoiceDetailRepository.Insert(detail);
                        break;
                    case InvoiceDetailActionType.Update:
                        var existingInvoiceDetail = _invoiceDetailRepository.GetById(detail.Id, false);
                        detail.CreatedDate = existingInvoiceDetail.CreatedDate;
                        detail.UpdatedDate = DateTime.Now;
                        detail.InvoiceId = invoice.Id;
                        _invoiceDetailRepository.UpdateEntity(detail);
                        break;
                    case InvoiceDetailActionType.Delete:
                        existingInvoiceDetail = _invoiceDetailRepository.GetById(detail.Id);
                        _invoiceDetailRepository.Delete(existingInvoiceDetail);
                        break;
                }
            }

            var invoiceData = _invoiceRepository.SearchFor(x => x.Id == existingSaleBill.Id, "InvoiceDetail").FirstOrDefault();
            return new BaseResponse<Invoice>() { Success = true, Data = invoiceData };
        }

        private BaseResponse<Invoice> validateOrderModal(Invoice orderModel)
        {
            var invoiceDetail = JsonConvert.DeserializeObject<List<InvoiceDetail>>(orderModel.InvoiceDetailJson);
            if (invoiceDetail == null)
            {
                return new BaseResponse<Invoice>() { Success = false, Response = "Please select any product" };
            }
            if (invoiceDetail.Count == 0)
            {
                return new BaseResponse<Invoice>() { Success = false, Response = "Please select any product" };
            }

            foreach (var detail in invoiceDetail)
            {
                if (string.IsNullOrEmpty(detail.ProductName))
                {
                    return new BaseResponse<Invoice>() { Success = false, Response = "Please select any product" };
                }
            }
            return new BaseResponse<Invoice>() { Success = true };
        }

        public List<Invoice> ListByLeadIdAndOrderStatus(int leadId, string orderStatus)
        {
            var query = _invoiceRepository.SearchFor().AsQueryable();

            if (leadId > 0)
            {
                query = query.Where(m => m.LeadId == leadId);
            }

            if (!string.IsNullOrEmpty(orderStatus))
            {
                Enum.TryParse(orderStatus, out OrderStatusType orderStatusType);
                query = query.Where(m => m.OrderStatus == orderStatusType);
            }

            return query.ToList();
        }

        public List<Invoice> ByLeadIds(List<int> leadIds)
        {
            return _invoiceRepository.SearchFor(m => leadIds.Contains(m.LeadId)).OrderByDescending(x => x.Id).ToList();
        }

        public List<Invoice> ListById(int id)
        {
            return _invoiceRepository.SearchFor(x => x.Id == id, "Lead,InvoiceDetail").ToList();
        }
    }
}
