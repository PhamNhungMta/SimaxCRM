using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadProductMapping")]
    public class LeadProductMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadId { get; set; }

        public int ProductId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        public virtual Lead Lead { get; set; }

        public virtual Product Product { get; set; }


    }
}
