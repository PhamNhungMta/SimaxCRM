using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadProjectMapping")]
    public class LeadProjectMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadId { get; set; }

        public int ProjectId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        [ForeignKey("LeadId")]
        public virtual Lead Lead { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }


    }
}
