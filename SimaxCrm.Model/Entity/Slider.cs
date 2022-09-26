using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Slider")]
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public string ImagePath { get; set; }
        public string Url { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        //TableProperties

    }


}
