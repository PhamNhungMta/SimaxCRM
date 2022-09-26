using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("InventoryTagMapping")]
    public class InventoryTagMapping
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int ProductId { get; set; }

        public int InventoryTagId { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        //TableProperties

        public virtual Product Product { get; set; }

        public virtual InventoryTag InventoryTag { get; set; }


    }
}
