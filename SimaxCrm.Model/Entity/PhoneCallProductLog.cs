using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("PhoneCallProductLog")]
    public class PhoneCallProductLog : PhoneCallLogBase
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
