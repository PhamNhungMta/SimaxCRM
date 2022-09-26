using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.RequestModel
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string BillDate { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal SubAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal TaxRate { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal OtherCharges { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal TaxAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal DiscountAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal GrandTotal { get; set; }
        public string Company { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyTax { get; set; }
        public string ComapnyContact { get; set; }
        public byte[] Logo { get; set; }
        public string CurrencySymbol { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal TaxPercent { get; set; }

    }

    public class InvoiceModelProduct
    {
        public string Product { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Qty { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal Amount { get; set; }
        [Column(TypeName = "decimal(18,2)")] public decimal TotalAmount { get; set; }
    }

}
