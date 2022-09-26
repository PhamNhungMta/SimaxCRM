using Microsoft.AspNetCore.Identity;
using SimaxCrm.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimaxCrm.Model.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public string Name { get; set; }
        public int Tid { get; set; }
        public virtual List<Lead> Lead { get; set; }
        public virtual List<Lead> LeadDeletedBy { get; set; }
        public virtual List<CallLog> CallLog { get; set; }
        public virtual List<UserLog> UserLog { get; set; }
        public virtual List<LeadAutoAssign> LeadAutoAssign { get; set; }
        public virtual List<LeadAutoAssignLog> LeadAutoAssignLog { get; set; }
        public virtual List<Message> Message { get; set; }
        public virtual List<MessageDetail> MessageDetail { get; set; }
        public virtual List<PhoneCallProductLog> PhoneCallProductLog { get; set; }
        public virtual List<PhoneCallLeadLog> PhoneCallLeadLog { get; set; }
        public virtual List<Wallet> Wallet { get; set; }
        public virtual List<PaymentLog> PaymentLog { get; set; }
        public virtual List<LeadOrder> LeadOrder { get; set; }
        public virtual ICollection<CustomerQuery> CustomerQuery { get; set; }
        public virtual ICollection<Wishlist> Wishlist { get; set; }
        public virtual ICollection<UserRating> UserRating { get; set; }
        public virtual ICollection<UserRating> UserRatingCreatedBy { get; set; }
        public int? AgentCount { get; set; }
        public int? QaCount { get; set; }
        public int? AccountCount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public string ImagePath { get; set; }
        public string Experience { get; set; }
        public string WorkingEmployees { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public UserRank UserRank { get; set; }
        public string CompanyName { get; set; }

        public string RERANo { get; set; }

        public string News { get; set; }

        public string LanguageSpeak { get; set; }

        public string Specializations { get; set; }




        [NotMapped]
        public List<Product> Product { get; set; }


        [NotMapped]
        public bool IsActiveMarge
        {
            get
            {
                if (IsActive)
                {
                    if (StartDate.HasValue && EndDate.HasValue)
                    {
                        if (DateTime.Now.Date >= StartDate.Value.Date && DateTime.Now.Date <= EndDate.Value.Date)
                        {
                            return true;
                        }
                    }
                    else if (StartDate.HasValue && !EndDate.HasValue)
                    {
                        if (DateTime.Now.Date >= StartDate.Value.Date)
                        {
                            return true;
                        }
                    }
                    else if (!StartDate.HasValue && EndDate.HasValue)
                    {
                        if (DateTime.Now.Date <= EndDate.Value.Date)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                    return false;
                }
                return IsActive;
            }
        }

        

        [NotMapped]
        public string UserStatus
        {
            get
            {
                if (StartDate != null && EndDate != null)
                {
                    if (EndDate < DateTime.Now.Date)
                    {
                        return "Expired";
                    }
                    else
                    {
                        var days = (EndDate.Value - StartDate.Value).TotalDays;
                        if (days == 7)
                        {
                            return "Free";
                        }
                    }
                }
                return "Paid";
            }
        }

        public bool ShowInHomePage { get; set; }
    }
}
