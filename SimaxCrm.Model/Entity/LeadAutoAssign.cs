using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadAutoAssign")]
    public class LeadAutoAssign
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        //[Required(ErrorMessage = "Enter Handle Query")]
        //[Display(Name = "Handle Query")]
        //public int HandleQuery { get; set; }

        [Required(ErrorMessage = "Select Agent")]
        [Display(Name = "Agent")]
        public string UserId { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        public virtual ApplicationUser User { get; set; }

        public virtual List<LeadAutoAssignSourceMapping> LeadAutoAssignSourceMapping { get; set; }

        [NotMapped]
        [Display(Name = "Lead Sources")]
        public string LeadSources { get; set; }


    }
}
