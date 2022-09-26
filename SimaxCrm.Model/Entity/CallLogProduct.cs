using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("CallLogProduct")]
    public class CallLogProduct
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int ProductId { get; set; }

        public string UserId { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Remarks { get; set; }

        [Required]
        public string Message { get; set; }

        [Display(Name = "Remind At")]
        public DateTime? AlertDate { get; set; }

        public AlertStatusType AlertStatus { get; set; }
        public AlertStatusType AlertStatusFcm { get; set; }
        
        public DateTime CreatedDate { get; set; }

        //TableProperties

        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int? InvoiceId { get; set; }
    }
}
