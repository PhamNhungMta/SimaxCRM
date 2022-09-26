using SimaxCrm.Model.Enum;
using SimaxCrm.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("Product")]
    public class Product: PropertyModel
    {
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }


        [MaxLength(200)]
        [Display(Name = "Browse Image 1")]
        public string ImagePath1 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 2")]
        public string ImagePath2 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 3")]
        public string ImagePath3 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 4")]
        public string ImagePath4 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 5")]
        public string ImagePath5 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 6")]
        public string ImagePath6 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 7")]
        public string ImagePath7 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 8")]
        public string ImagePath8 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 9")]
        public string ImagePath9 { get; set; }

        [MaxLength(200)]
        [Display(Name = "Browse Image 10")]
        public string ImagePath10 { get; set; }

        [NotMapped]
        public string IdStr
        {
            get
            {
                var str = "P";
                foreach (char c in Id.ToString())
                {
                    Char c1 = (Char)(65 + (int.Parse(c.ToString())));
                    str += c1;
                    str += c.ToString();
                }
                return str;
            }
        }

        public virtual List<LeadProductMapping> LeadProductMapping { get; set; }
        public virtual List<AttachmentProductMapping> AttachmentProductMapping { get; set; }
        public virtual List<InventoryTagMapping> InventoryTagMapping { get; set; }
        public virtual List<CallLogProduct> CallLogProduct { get; set; }
        public virtual List<PhoneCallProductLog> PhoneCallProductLog { get; set; }
        public virtual List<UserRating> UserRating { get; set; }
        public virtual Location Location { get; set; }
        public virtual Society Society { get; set; }
        public virtual ICollection<CustomerQuery> CustomerQuery { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }

        
    }
}
