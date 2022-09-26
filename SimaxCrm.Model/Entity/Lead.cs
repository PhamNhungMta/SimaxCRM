using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    [Table("Lead")]
    public class Lead
    {
        [Key]
        [Display(Name = "Lead Id")]
        public int Id { get; set; }

        public int Tid { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [MaxLength(200)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [MaxLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [MaxLength(20)]
        [Display(Name = "Alternate Phone Name")]
        public string AlternatePhoneNumber { get; set; }

        [MaxLength(20)]
        [Display(Name = "Refer Phone Number")]
        public string ReferPhoneNumber { get; set; }

        [MaxLength(200)]
        [Display(Name = "Lead Type")]
        [Required]
        public string LeadType { get; set; }

        [MaxLength(200)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MaxLength(500)]
        [Display(Name = "Address")]
        public string Address { get; set; }


        //[MaxLength(200)]
        [Display(Name = "Property Category")]
        [Required]
        public int PropertyCategoryId { get; set; }

        [Display(Name = "Property Subcategory")]
        public int PropertySubcategoryId { get; set; }

        [Display(Name = "Property City")]
        public int CityId { get; set; }

        [Display(Name = "Sector/Location")]
        public int LocationId { get; set; }

        [Display(Name = "Building/Society")]
        public int SocietyId { get; set; }

        [MaxLength(200)]
        [Display(Name = "ReferName")]
        public string ReferName { get; set; }

        [Display(Name = "Budget Min")]
        public decimal BudgetMin { get; set; }

        [Display(Name = "Budget Max")]
        public decimal BudgetMax { get; set; }

        [MaxLength(200)]
        [Display(Name = "City")]
        public string City { get; set; }

        [MaxLength(200)]
        [Display(Name = "State")]
        public string State { get; set; }

        [MaxLength(200)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [MaxLength(20)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Lead Source")]
        public int LeadSourceId { get; set; }

        [Display(Name = "Name")]
        public DateTime? LastContact { get; set; }

        [Display(Name = "Assigned To")]
        public string UserId { get; set; }

        [MaxLength(50)]
        public string LeadStatus { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedDate { get; set; }

        public bool IsPurchased { get; set; }
        public int? PurchasedCount { get; set; }

        //[Display(Name = "Type")]
        //[MaxLength(50)]
        //public string Type { get; set; }

        public DateTime AssignedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Follow Up")]
        public DateTime? AlertDate { get; set; }

        public string CreatedBy { get; set; }

        public virtual LeadSource LeadSource { get; set; }
        public virtual List<LeadTagMapping> LeadTagMapping { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser DeletedBy { get; set; }
        public virtual List<CallLog> CallLog { get; set; }
        public virtual List<UserLog> UserLog { get; set; }
        public virtual List<LeadAutoAssignLog> LeadAutoAssignLog { get; set; }
        public virtual List<Invoice> Invoice { get; set; }
        public virtual List<LeadProductMapping> LeadProductMapping { get; set; }
        //public virtual List<LeadLocationMapping> LeadLocationMapping { get; set; }
        //public virtual List<LeadSocietyMapping> LeadSocietyMapping { get; set; }
        public virtual List<Tcf> Tcf { get; set; }


        [NotMapped]
        [Display(Name = "Lead Tags")]
        public string LeadTags { get; set; }

        //[NotMapped]
        //[Display(Name = "Sector/Location")]
        //public string Locations { get; set; }

        //[NotMapped]
        //[Display(Name = "Building/Society")]
        //public string Societys { get; set; }

        [NotMapped]
        [Display(Name = "Offered Property")]
        public string ProductIds { get; set; }


        public virtual List<PhoneCallLeadLog> PhoneCallLeadLog { get; set; }
        public virtual List<LeadOrderDetail> LeadOrderDetail { get; set; }
        public virtual List<LeadProjectMapping> LeadProjectMapping { get; set; }


        [NotMapped]
        public string IdStr
        {
            get
            {
                var str = "L";
                foreach (char c in Id.ToString())
                {
                    Char c1 = (Char)(65 + (int.Parse(c.ToString())));
                    str += c1;
                    str += c.ToString();
                }
                return str;
            }
        }


        [NotMapped]
        [Display(Name = "Total Time")]
        public string AssignedDuration
        {
            get
            {
                return DateAndTimeDiff((DateTime)this.AssignedDate, DateTime.Now);
            }
        }

        [NotMapped]
        public int TempLeadId { get; set; }

        private static string DateAndTimeDiff(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan span = (dateTime2 - dateTime1);
            if (span.Days > 0)
                return string.Format("{0}d, {1}h, {2}m", span.Days, span.Hours, span.Minutes);
            else if (span.Hours > 0)
                return string.Format("{0}h, {1}m", span.Hours, span.Minutes);
            else
                return string.Format("{0}m", span.Minutes);
        }

        [NotMapped]
        public string TeamEmailId { get; set; }
        
    }


}
