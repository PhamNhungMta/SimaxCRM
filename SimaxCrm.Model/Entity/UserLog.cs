using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("UserLog")]
    public class UserLog
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadId { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Select Text Type")]
        [Display(Name = "Text Type")]
        public string LogType { get; set; }

        [Required(ErrorMessage = "Select Text")]
        [Display(Name = "Text")]
        public int LogRecId { get; set; }

        public string LogText { get; set; }

        public string LogStatus { get; set; }

        public bool IsSuccess { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Lead Lead { get; set; }
        public virtual ApplicationUser User { get; set; }










    }
}
