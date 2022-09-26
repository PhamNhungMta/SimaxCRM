using SimaxCrm.Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace SimaxCrm.Model.RequestModel
{
    public class UserRegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Phone { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public int Tid { get; set; }
    }
}