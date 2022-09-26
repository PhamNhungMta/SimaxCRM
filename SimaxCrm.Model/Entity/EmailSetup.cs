using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("EmailSetup")]
    public class EmailSetup
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter SMTP Server Address")]
        [MaxLength(100)]
        [Display(Name = "SMTP Server")]
        public string SmtpServer { get; set; }

        [Required(ErrorMessage = "Enter SMTP Port")]
        [Display(Name = "SMTP Port")]
        public int SmtpPort { get; set; }

        [Required(ErrorMessage = "Select Any Value in SSL")]
        [Display(Name = "Use SSL")]
        [MaxLength(5)]
        public string UseSsl { get; set; }

        [MaxLength(200)]
        [Display(Name = "Username (Optional)")]
        public string Username { get; set; }

        [MaxLength(200)]
        [Display(Name = "Password (Optional)")]
        public string Password { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [Required]
        public string IncommingMailServer { get; set; }
        [Required]
        public int IncommingMailPort { get; set; }

        //TableProperties










    }
}
