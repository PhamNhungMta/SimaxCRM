using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("CustomerQuery")]
    public class CustomerQuery
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required(ErrorMessage ="Please Enter Your Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]

        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Your Message")]
        public string CustomerMessage { get; set; }
        public string ProjectRelatedIds { get; set; }
        public string ProductRelatedIds { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
