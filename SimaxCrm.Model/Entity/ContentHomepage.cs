using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("ContentHomepage")]
    public class ContentHomepage
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }
        public string? AgentId { get; set; }
        public string? CompanyId { get; set; }
        public string? BranchId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
