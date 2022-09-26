using SimaxCrm.Model.Entity;
using SimaxCrm.Model.ResponseModel;
using System.Collections.Generic;

namespace SimaxCrm.Service.Interface
{
    public interface IInvoiceService
    {
        List<Invoice> List();
        Invoice ById(int id);
        BaseResponse<Invoice> Create(Invoice serviceType);
        BaseResponse<Invoice> Update(Invoice serviceType);
        void Delete(int id);
        List<Invoice> ListByLeadIdAndOrderStatus(int leadId, string orderStatus);
        List<Invoice> ByLeadIds(List<int> leadIds);
        void UpdateOnly(Invoice invoice);
        List<Invoice> ListById(int id);
    }
}
