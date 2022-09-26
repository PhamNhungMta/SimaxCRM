using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.RequestModel
{
    public class PropertyModel
    {
        [Key]
        public int Id { get; set; }
        public int Tid { get; set; }

        [Display(Name = "Property Category")]
        [Required]
        public int PropertyCategoryId { get; set; }

        [Display(Name = "Property Subcategory")]
        [Required]
        public int PropertySubcategoryId { get; set; }

        [Required(ErrorMessage = "Enter Property Title")]
        [MaxLength(200)]
        [Display(Name = "Property Title")]
        public string Name { get; set; }

        //[MaxLength(2000)]
        [Display(Name = "Property Description")]
        public string Description { get; set; }
        [Display(Name = "Meta Keyword")]
        public string MetaTag { get; set; }
        [Display(Name = "Meta Description")]
        public string MetaDescription { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Locality/Sector")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Building/Society")]
        public int SocietyId { get; set; }


        [MaxLength(500)]
        [Display(Name = "Address")]
        public string AddressPlain { get; set; }

        [MaxLength(500)]
        [Display(Name = "Google Location")]
        public string Address { get; set; }
        public string AddressLat { get; set; }
        public string AddressLng { get; set; }

        [Display(Name = "Property Type")]
        public string Type { get; set; }

        [Display(Name = "Please Select")]
        public string PropertyDimType { get; set; }

        [Required]
        [Display(Name = "Total Area")]
        public decimal TotalArea { get; set; }

        [Required]
        [Display(Name = "Property Price/Sq.Ft. or Sq.Mt.")]
        public decimal PropertyPrice { get; set; }

        [Display(Name = "Total Property Price Rs.")]
        public string TotalPropertyPrice { get; set; }

        [Display(Name = "Construction Status")]
        public string ConstructionStatus { get; set; }

        [Display(Name = "Bedroom")]
        public string Bedroom { get; set; }

        [Display(Name = "Parking")]
        public string Parking { get; set; }

        [Display(Name = "Bathrooms")]
        public string Bathrooms { get; set; }

        [Display(Name = "Maintenance Charges/Sq.Ft. Rs.")]
        public string MaintenanceCharges { get; set; }

        [Display(Name = "Total Maintenance Charges Rs.")]
        public string TotalMaintenanceCharges { get; set; }

        [Display(Name = "Centralized Ac")]
        public bool CentralizedAc { get; set; }

        [Display(Name = "Security Guard")]
        public bool SecurityGuard { get; set; }

        [Display(Name = "Fire Safety")]
        public bool FireSafety { get; set; }

        [Display(Name = "Cctv Camera")]
        public bool CctvCamera { get; set; }

        [Display(Name = "Lift")]
        public bool Lift { get; set; }

        [Display(Name = "club")]
        public bool club { get; set; }

        [Display(Name = "Swimming pool")]
        public bool SwimmingPool { get; set; }

        [Display(Name = "Garden area")]
        public bool GardenArea { get; set; }

        [Display(Name = "kids play area")]
        public bool KidsPlayArea { get; set; }

        [Display(Name = "Gym")]
        public bool Gym { get; set; }

        [Display(Name = "Property Floor")]
        public string PropertyFloor { get; set; }

        [Display(Name = "Furnished")]
        public string Furnished { get; set; }

        [Display(Name = "Max Sale Rate")]
        public decimal MaxSaleRate { get; set; }

        [Display(Name = "Owner Name")]
        public string OwnerName { get; set; }

        [Display(Name = "Owner Phone Number")]
        public string OwnerPhoneNumber { get; set; }

        [Display(Name = "Owner Email Id")]
        public string OwnerEmailId { get; set; }

        [Display(Name = "Source")]
        public string Source { get; set; }


        [Display(Name = "Reference Name")]
        public string ReferenceName { get; set; }

        [Display(Name = "Reference Number")]
        public string ReferenceNumber { get; set; }

        [MaxLength(1000)]
        [Display(Name = "Browse Main Image")]
        public string MainImage { get; set; }


        [Display(Name = "Embad Video")]
        public string EmbadVideo { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public ItemActiveStatusType ActiveStatus { get; set; }
        public string Status { get; set; }
        public int ViewCount { get; set; }
        
        public int RecIdOld { get; set; }

        [MaxLength(300)]
        public string VideoLink { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [NotMapped]
        [Display(Name = "Inventory Tags")]
        public string InventoryTags { get; set; }

        [NotMapped]
        public string Price { get { return TotalPropertyPrice; } }

        [NotMapped]
        public bool CanView { get; set; }
        
        [NotMapped]
        public string UserStr { get; set; }

        [NotMapped]
        public string TempId { get; set; }

        public DateTime? AlertDate { get; set; }
        
        [NotMapped]
        public int Sno { get; set; }


        [NotMapped]
        public bool IsWishlist { get; set; }

        [NotMapped]
        public string MaxSaleRateString
        {
            get
            {
                string budgetString = "";
                if (MaxSaleRate >= 10000000)
                {
                    budgetString = Math.Round(MaxSaleRate / 10000000, 1) + " Cr";
                }
                else if (MaxSaleRate >= 100000)
                {
                    budgetString = Math.Round(MaxSaleRate / 100000, 1) + " Lacs";
                }
                else
                {
                    budgetString = MaxSaleRate.ToString();
                }
                return budgetString;
            }
        }
    }
}