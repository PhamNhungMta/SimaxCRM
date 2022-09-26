using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("UserRating")]
    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }



        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }


        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public string Message { get; set; }
        public double Rating { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedByUser { get; set; }

        [NotMapped]
        public string UrlSlug { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public int RatingRowsCount { get; set; }
    }
}