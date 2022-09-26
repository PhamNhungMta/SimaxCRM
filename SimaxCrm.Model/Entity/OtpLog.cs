using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("OtpLog")]
    public class OtpLog
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }
        public OtpSentType SentType { get; set; }
        public string SentTo { get; set; }
        public string Pin { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string ApiResponse { get; set; }
    }
}
