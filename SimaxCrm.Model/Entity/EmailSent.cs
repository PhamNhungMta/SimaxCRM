using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("EmailSent")]
    public class EmailSent
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }
        [Required]
        [Display(Name = "From Email")]
        public string FromEmail { get; set; }
        [Required]
        public string ToEmail { get; set; }
        public string SendBy { get; set; }
        public bool IsSent { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
