using SimaxCrm.Data.Repository.Interface;
using SimaxCrm.Model.Entity;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimaxCrm.Service.Implementation
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly IInvoiceDetailRepository _invoiceDetailRepository;
        public InvoiceDetailService(IInvoiceDetailRepository invoiceDetailRepository)
        {
            _invoiceDetailRepository = invoiceDetailRepository;
        }

        public void Create(InvoiceDetail invoiceDetail)
        {
            _invoiceDetailRepository.Insert(invoiceDetail);
        }

        public void Delete(int id)
        {
            var obj = _invoiceDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
            obj.UpdatedDate = DateTime.Now;
            _invoiceDetailRepository.UpdateEntity(obj);
        }

        public void Update(InvoiceDetail invoiceDetail)
        {
            _invoiceDetailRepository.UpdateEntity(invoiceDetail);
        }

        public List<InvoiceDetail> List()
        {
            return _invoiceDetailRepository.SearchFor().OrderByDescending(x => x.Id).ToList();
        }

        public InvoiceDetail ById(int id)
        {
            return _invoiceDetailRepository.SearchFor(x => x.Id == id).FirstOrDefault();
        }

    }
}
