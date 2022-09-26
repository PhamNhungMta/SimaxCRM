using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("LeadRemarks")]
    public class LeadRemarks
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        [MaxLength(200)]
        [Display(Name = "Status")]
        public string Status { get; set; }


        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties






    }
}
