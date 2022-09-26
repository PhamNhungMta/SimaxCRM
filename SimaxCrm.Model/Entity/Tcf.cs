using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimaxCrm.Model.Entity
{
    [Table("Tcf")]
    public class Tcf
    {
        [Key]
        public int Id { get; set; }

        public int Tid { get; set; }

        public int LeadId { get; set; }

        [Display(Name = "Property")]
        public string Property { get; set; }

        [Display(Name = "Rate")]
        public string Rate { get; set; }

        [Display(Name = "Size")]
        public string Size { get; set; }

        [Display(Name = "BSP")]
        public string BSP { get; set; }

        [Display(Name = "Other Charges")]
        public string OtherCharges { get; set; }

        [Display(Name = "Booking Form")]
        public string BookingForm { get; set; }

        [Display(Name = "Payment Details")]
        public string PaymentDetails { get; set; }

        [Display(Name = "Ops Check list")]
        public string OpsChecklist { get; set; }

        [Display(Name = "Discount Approval")]
        public string DiscountApproval { get; set; }

        [Display(Name = "Aadhar Card")]
        public string AadharCard { get; set; }

        [Display(Name = "Pan Card")]
        public string PanCard { get; set; }

        [Display(Name = "Voter ID")]
        public string VoterID { get; set; }

        [Display(Name = "Passport")]
        public string Passport { get; set; }

        [Display(Name = "Brokerage Rate")]
        public string BrokerageRate { get; set; }

        [Display(Name = "Royalty Discount")]
        public string RoyaltyDiscount { get; set; }

        [Display(Name = "Referral Brokerage")]
        public string ReferralBrokerage { get; set; }

        [Display(Name = "Final Brokerage")]
        public string FinalBrokerage { get; set; }

        [Display(Name = "Employee Code")]
        public string EmployeeCode { get; set; }

        public virtual Lead Lead { get; set; }









    }
}
