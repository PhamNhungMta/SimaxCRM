using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("SubCategory")]
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
        //public virtual List<LeadSubCategoryMapping> LeadSubCategoryMapping { get; set; }
        //public virtual List<Product> Product { get; set; }
        //public virtual List<Project> Project { get; set; }

    }
}
