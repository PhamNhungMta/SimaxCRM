using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("ProjectTagMapping")]
    public class ProjectTagMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int ProjectId { get; set; }

        public int InventoryTagId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [ForeignKey("InventoryTagId")]
        public virtual InventoryTag InventoryTag { get; set; }


    }
}
