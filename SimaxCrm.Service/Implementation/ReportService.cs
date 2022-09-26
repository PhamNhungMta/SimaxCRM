using AspNetCore.Reporting;
using AutoMapper;
using SimaxBilling.Model.Enum;
using SimaxCrm.Model.Entity;
using SimaxCrm.Model.RequestModel;
using SimaxCrm.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SimaxCrm.Service.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ISystemSetupService _systemSetupService;
        private readonly IMapper _mapper;

        public ReportService(IInvoiceService invoiceService,
            ISystemSetupService systemSetupService)
        {
            _invoiceService = invoiceService;
            _systemSetupService = systemSetupService;

            MapperConfiguration config = autoMapperConfig();
            _mapper = config.CreateMapper();
        }

        private static MapperConfiguration autoMapperConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Invoice, InvoiceModel>()
                .ForMember(
                    dest => dest.Customer,
                    opt => opt.MapFrom(src => src.Lead.Name)
                )
                .ForMember(
                    dest => dest.BillDate,
                    opt => opt.MapFrom(src => src.CreatedDate.ToString("dd/MM/yyyy"))
                )
                .ForMember(
                    dest => dest.SubAmount,
                    opt => opt.MapFrom(src => src.TotalAmount)
                );

                cfg.CreateMap<InvoiceDetail, InvoiceModelProduct>()
                .ForMember(
                    dest => dest.Product,
                    opt => opt.MapFrom(src => src.ProductName)
                );
            });
        }


        public ImagePath GetBillInvoice(int id, string contentRootPath, ReportFormType reportFormType, ReportType reportType)
        {
            var reportPath = contentRootPath;
            var setup = _systemSetupService.List().FirstOrDefault();
            var logoPath = contentRootPath + "\\wwwroot\\" + setup.CompanyLogo;
            List<InvoiceModel> invoiceModal = null;
            List<InvoiceModelProduct> invoiceModalDetail = null;
            setInvoiceDataFormWise(id, reportFormType, ref reportPath, setup, logoPath, ref invoiceModal, ref invoiceModalDetail);
            var pdfPath = generateInvoiceFile(reportType, contentRootPath, reportPath, invoiceModal, invoiceModalDetail);
            return pdfPath;
        }

        private void setInvoiceDataFormWise(int id, ReportFormType reportFormType, ref string reportPath, SystemSetup setup, string logoPath, ref List<InvoiceModel> invoiceModal, ref List<InvoiceModelProduct> invoiceModalDetail)
        {
            switch (reportFormType)
            {
                case ReportFormType.Invoice:
                    reportPath = getDataForSaleBillReport(id, reportPath, setup, logoPath, ref invoiceModal, ref invoiceModalDetail);
                    break;
            }
        }

        public byte[] GetBillInvoiceBytes(int id, string contentRootPath, ReportFormType reportFormType, ReportType reportType)
        {
            var reportPath = contentRootPath;
            var setup = _systemSetupService.List().FirstOrDefault();
            var logoPath = contentRootPath + "\\wwwroot\\" + setup.CompanyLogo;
            List<InvoiceModel> invoiceModal = null;
            List<InvoiceModelProduct> invoiceModalDetail = null;

            setInvoiceDataFormWise(id, reportFormType, ref reportPath, setup, logoPath, ref invoiceModal, ref invoiceModalDetail);

            var result = generateInvoiceFileBytes(reportType, reportPath, invoiceModal, invoiceModalDetail);
            return result.MainStream;
        }

        private string getDataForSaleBillReport(int id, string reportPath, SystemSetup setup, string logoPath, ref List<InvoiceModel> invoiceModal, ref List<InvoiceModelProduct> invoiceModalDetail)
        {
            reportPath = reportPath + "\\wwwroot\\Uploads\\RDLC\\Invoice.rdlc";
            var objBill = _invoiceService.ListById(id);
            invoiceModal = _mapper.Map<List<InvoiceModel>>(objBill);
            invoiceModal[0].Company = setup.CompanyName;
            invoiceModal[0].CurrencySymbol = setup.CurrencySymbol;
            invoiceModal[0].CompanyAddress = setup.AddressPlain + "<br>" + setup.CompanyContact + "<br>" + setup.CompanyGstNumber;

            FileAttributes attr = File.GetAttributes(logoPath);
            if (!((attr & FileAttributes.Directory) == FileAttributes.Directory))
            {
                invoiceModal[0].Logo = File.ReadAllBytes(logoPath);
            }

            var billDetail = objBill.SelectMany(m => m.InvoiceDetail).ToList();
            invoiceModalDetail = _mapper.Map<List<InvoiceModelProduct>>(billDetail);
            return reportPath;
        }

        private ImagePath generateInvoiceFile(ReportType reportType, string rootPath, string ReportPath, dynamic tblInvoice, dynamic tblProduct = null, dynamic tblTax = null)
        {
            var result = generateInvoiceFileBytes(reportType, ReportPath, tblInvoice, tblProduct, tblTax);

            string filename = DateTime.Now.ToFileTime() + "." + reportType;
            var imagePath = new ImagePath(rootPath, Model.Enum.FolderType.Invoice, filename);

            using (FileStream fs = File.Create(imagePath.physicalPath))
            {
                fs.Write(result.MainStream, 0, result.MainStream.Length);
            }
            return imagePath;
        }

        private ReportResult generateInvoiceFileBytes(ReportType reportType, string ReportPath, dynamic tblInvoice, dynamic tblProduct = null, dynamic tblTax = null)
        {

            string fileDirPath = Assembly.GetExecutingAssembly().Location.Replace("ReportAPI.dll", string.Empty);
            string rdlcFilePath = ReportPath;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding.GetEncoding("windows-1252");
            LocalReport report = new LocalReport(rdlcFilePath);

            if (tblInvoice != null)
            {
                report.AddDataSource("DataSet1_Ledger", tblInvoice);
            }
            if (tblProduct != null)
            {
                report.AddDataSource("DataSet1_product", tblProduct);
            }
            if (tblTax != null)
            {
                report.AddDataSource("DataSet1_tax", tblTax);
            }

            var result = report.Execute(GetRenderType(reportType.ToString()), 1, parameters);
            return result;
        }

        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;
            switch (reportType.ToLower())
            {
                default:
                case "pdf":
                    renderType = RenderType.Pdf;
                    break;
                case "doc":
                    renderType = RenderType.Word;
                    break;
                case "xls":
                    renderType = RenderType.Excel;
                    break;
            }

            return renderType;
        }
    }
}
