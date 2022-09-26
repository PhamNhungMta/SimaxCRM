using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("Wallet")]
    public class Wallet
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public string UserId { get; set; }

        [Column(TypeName = "decimal(18,2)")] public decimal TotalPoints { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public virtual ApplicationUser User { get; set; }
     
        public virtual List<WalletDetail> WalletDetail { get; set; }
        public int PurchaseCount { get; set; }
    }
}
