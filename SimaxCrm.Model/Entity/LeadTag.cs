using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadTag")]
    public class LeadTag
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


        public virtual List<LeadTagMapping> LeadTagMapping { get; set; }

    }
}
