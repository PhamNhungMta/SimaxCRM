using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadOrderDetail")]
    public class LeadOrderDetail
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadOrderId { get; set; }

        public int LeadId { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal Amount { get; set; }

        public DateTime CreatedDate { get; set; }

        //TableProperties        
        public virtual LeadOrder LeadOrder { get; set; }
        public virtual Lead Lead { get; set; }
        public int NewLeadId { get; set; }
    }
}
