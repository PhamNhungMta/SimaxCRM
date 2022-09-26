using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("InvoiceDetail")]
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int InvoiceId { get; set; }

        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Qty { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual Invoice Invoice { get; set; }

        public InvoiceDetailActionType ActionType { get; set; }
    }

    public enum InvoiceDetailActionType
    {
        Insert = 1,
        Update,
        Delete
    }
}
