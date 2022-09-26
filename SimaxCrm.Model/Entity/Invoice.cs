using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [Display(Name = "Invoice ID")]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Discount Amount")]
        public decimal DiscountAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Other Charges")]
        public decimal OtherCharges { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Tax Percent")]
        public decimal TaxPercent { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Grand Total")]
        public decimal GrandTotal { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Order Status")]
        public OrderStatusType OrderStatus { get; set; }

        [Display(Name = "Dated")]
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public string InvoiceDetailJson { get; set; }

        public virtual Lead Lead { get; set; }

        public virtual List<InvoiceDetail> InvoiceDetail { get; set; }

        [NotMapped]
        public string Company { get; set; }
        [NotMapped]
        public string CurrencySymbol { get; set; }
        [NotMapped]
        public string CompanyAddress { get; set; }
        [NotMapped]
        public byte[] Logo { get; set; }
    }
}
