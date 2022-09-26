using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Message")]
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Message")]
        public string Body { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedById { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual List<MessageDetail> MessageDetail { get; set; }

        [NotMapped]
        public string Users { get; set; }


    }
}
