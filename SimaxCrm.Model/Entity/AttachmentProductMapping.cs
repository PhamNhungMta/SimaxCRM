using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("AttachmentProductMapping")]
    public class AttachmentProductMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int ProductId { get; set; }
        public int? UploadCategoryId { get; set; }

        [ForeignKey("UploadCategoryId")]
        public virtual UploadCategory UploadCategory { get; set; }

        public int AttachmentId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("AttachmentId")]
        public virtual Attachment Attachment { get; set; }
    }
}
