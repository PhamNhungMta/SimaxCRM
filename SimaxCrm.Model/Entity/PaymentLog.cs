using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("PaymentLog")]
    public class PaymentLog
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public string UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal Amount { get; set; }

        public string TransId { get; set; }

        public PaymentLogStatusType Status { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual List<WalletDetail> WalletDetail { get; set; }
        public virtual List<LeadOrder> LeadOrder { get; set; }
    }
}
