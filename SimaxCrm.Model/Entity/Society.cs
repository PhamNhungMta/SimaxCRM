using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Society")]
    public class Society
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        //[ForeignKey("CityId")]
        //public virtual City City { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public virtual List<Product> Product { get; set; }
        public virtual List<Project> Project { get; set; }

    }
}
