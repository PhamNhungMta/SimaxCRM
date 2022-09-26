using SimaxBilling.Model.Enum;
using SimaxCrm.Model.RequestModel;

namespace SimaxCrm.Service.Interface
{
    public interface IReportService
    {
        ImagePath GetBillInvoice(int id, string contentRootPath, ReportFormType reportFormType, ReportType reportType);
        byte[] GetBillInvoiceBytes(int id, string contentRootPath, ReportFormType reportFormType, ReportType reportType);
    }
}
