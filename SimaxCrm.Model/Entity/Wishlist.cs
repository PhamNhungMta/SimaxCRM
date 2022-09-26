using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Wishlist")]
    public class Wishlist
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}