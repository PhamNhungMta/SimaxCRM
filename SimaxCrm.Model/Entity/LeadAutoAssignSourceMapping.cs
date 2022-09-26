using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadAutoAssignSourceMapping")]
    public class LeadAutoAssignSourceMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadAutoAssignId { get; set; }

        public int LeadSourceId { get; set; }

        public DateTime CreatedDate { get; set; }

        //TableProperties

        public virtual LeadAutoAssign LeadAutoAssign { get; set; }
        public virtual LeadSource LeadSource { get; set; }




    }
}
