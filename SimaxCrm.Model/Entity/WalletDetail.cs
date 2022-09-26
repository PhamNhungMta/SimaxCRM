using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("WalletDetail")]
    public class WalletDetail
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int WalletId { get; set; }

        public int PaymentLogId { get; set; }

        [Column(TypeName = "decimal(18,2)")] 
        [Display(Name ="Debit Points")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18,2)")] 
        [Display(Name ="Credit Points")]
        public decimal Credit { get; set; }

        public string Remarks { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Wallet Wallet { get; set; }
        public virtual PaymentLog PaymentLog { get; set; }

    }
}
