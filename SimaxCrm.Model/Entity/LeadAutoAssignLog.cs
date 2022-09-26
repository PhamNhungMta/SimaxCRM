using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadAutoAssignLog")]
    public class LeadAutoAssignLog
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }
        public int LeadId { get; set; }
        public int LeadSourceId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Lead Lead { get; set; }
        public virtual LeadSource LeadSource { get; set; }

    }
}
