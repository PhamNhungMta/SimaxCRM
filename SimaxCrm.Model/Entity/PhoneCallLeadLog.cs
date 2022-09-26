using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("PhoneCallLeadLog")]
    public class PhoneCallLeadLog : PhoneCallLogBase
    {
        public int LeadId { get; set; }
        public virtual Lead Lead { get; set; }
    }
}
