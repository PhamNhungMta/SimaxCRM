using SimaxCrm.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimaxCrm.Model.RequestModel
{
    public class RegistrationPasswordModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegistrationModel : RegistrationPasswordModel
    {

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string City { get; set; }
        public UserRank UserRank { get; set; }

        public bool ShowInHomePage { get; set; }

        public bool IsActive { get; set; }
    }

    public class RegistrationUpdateModel
    {
        public string Id { get; set; }
        public bool ShowInHomePage { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string CompanyName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string City { get; set; }
       
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

        [Display(Name = "Experience")]
        public string Experience { get; set; }

        [Display(Name = "Working Employees")]
        public string WorkingEmployees { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "RERA No")]
        public string RERANo { get; set; }

        [Display(Name = "Hobbies")]
        public string News { get; set; }

        [Display(Name = "Language Speak")]
        public string LanguageSpeak { get; set; }

        [Display(Name = "Specializations")]
        public string Specializations { get; set; }
    }
}
