using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadOrder")]
    public class LeadOrder
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public string UserId { get; set; }

        public int PaymentLogId { get; set; }

        [Column(TypeName = "decimal(18,2)")] 
        public decimal TotalAmount { get; set; }

        public int TotalLeads { get; set; }
        public LeadOrderStatusType LeadOrderStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual PaymentLog PaymentLog { get; set; }
        public virtual List<LeadOrderDetail> LeadOrderDetail { get; set; }
    }
}
