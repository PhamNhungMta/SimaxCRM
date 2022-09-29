using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadType")]
    public class LeadType
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? CompanyId { get; set; }

        public string? BranchId { get; set; }

        //public virtual List<LeadLeadTypeMapping> LeadLeadTypeMapping { get; set; }
        //public virtual List<Product> Product { get; set; }
        //public virtual List<Project> Project { get; set; }

    }
}
