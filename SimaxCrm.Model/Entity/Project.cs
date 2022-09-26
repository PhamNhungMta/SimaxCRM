using SimaxCrm.Model.RequestModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Project")]
    public class Project : PropertyModel
    {
        [NotMapped]
        public string IdStr
        {
            get
            {
                var str = "E";
                foreach (char c in Id.ToString())
                {
                    Char c1 = (Char)(65 + (int.Parse(c.ToString())));
                    str += c1;
                    str += c.ToString();
                }
                return str;
            }
        }
        public string TotalBlocks { get; set; }
        public string TotalFloors { get; set; }
        public string TotalFlats { get; set; }
        public virtual List<AttachmentProjectMapping> AttachmentProjectMapping { get; set; }
        public virtual List<ProjectTagMapping> ProjectTagMapping { get; set; }
        public virtual List<LeadProjectMapping> LeadProjectMapping { get; set; }
        public virtual Location Location { get; set; }
        public virtual Society Society { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<CustomerQuery> CustomerQuery { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual List<UserRating> UserRating { get; set; }
    }
}
