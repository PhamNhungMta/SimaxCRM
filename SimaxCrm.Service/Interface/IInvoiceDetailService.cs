using SimaxCrm.Model.Entity;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IInvoiceDetailService
    {
        List<InvoiceDetail> List();
        InvoiceDetail ById(int id);
        void Create(InvoiceDetail serviceType);
        void Update(InvoiceDetail serviceType);
        void Delete(int id);
    }
}
