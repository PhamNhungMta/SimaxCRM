using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Seo")]
    public class Seo
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }

        [Required]
        public SeoPage SeoPage { get; set; }

        [Required]
        [Display(Name ="Page Title")]
        public string PageTitle { get; set; }

        [Required]
        [Display(Name = "Meta Keyword")]
        public string MetaKeyword { get; set; }

        [Required]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
