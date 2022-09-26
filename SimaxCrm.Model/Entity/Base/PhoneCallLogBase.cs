using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    public class PhoneCallLogBase
    {
        [Key]
        public int Id { get; set; }
        public long RecId { get; set; }
        public int Tid { get; set; }
        public string UserId { get; set; }
        public string Date { get; set; }
        public DateTime CallTime { get; set; }
        public string Number { get; set; }
        public PhoneCallStatusType Type { get; set; }
        public int Duration { get; set; }
        public int IsNew { get; set; }
        public string CachedName { get; set; }
        public int CachedNumberType { get; set; }
        public string PhoneAccountId { get; set; }
        public string ViaNumber { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ApplicationUser User { get; set; }

        [NotMapped]
        public string DurationMin
        {
            get
            {
                TimeSpan time = TimeSpan.FromSeconds(Duration);
                return time.ToString();
            }
        }

    }
}
