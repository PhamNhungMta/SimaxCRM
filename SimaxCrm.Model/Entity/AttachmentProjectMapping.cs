using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("AttachmentProjectMapping")]
    public class AttachmentProjectMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int ProjectId { get; set; }
        public int? UploadCategoryId { get; set; }

        public int AttachmentId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [ForeignKey("AttachmentId")]
        public virtual Attachment Attachment { get; set; }

        [ForeignKey("UploadCategoryId")]
        public virtual UploadCategory UploadCategory { get; set; }
    }
}
