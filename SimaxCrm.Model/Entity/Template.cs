using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Template")]
    public class Template
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Type")]
        [Display(Name = "Type")]
        public TemplateType Type { get; set; }

        [Required(ErrorMessage = "Enter Text")]
        [Display(Name = "Text")]
        public string Text { get; set; }
        public string Subject { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        public string TextHtml { get; set; }

    }
}
