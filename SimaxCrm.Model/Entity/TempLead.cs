using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("TempLead")]
    public class TempLead
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [MaxLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        [NotMapped]
        public string IdStr
        {
            get
            {
                var str = "C";
                foreach (char c in Id.ToString())
                {
                    Char c1 = (Char)(65 + (int.Parse(c.ToString())));
                    str += c1;
                    str += c.ToString();
                }
                return str;
            }
        }

    }
}