using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("MessageDetail")]
    public class MessageDetail
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }
        public int MessageId { get; set; }

        public string SentToUserId { get; set; }

        public AlertStatusType AlertStatus { get; set; }

        public virtual ApplicationUser SentToUser { get; set; }
        public virtual Message Message { get; set; }


    }
}
