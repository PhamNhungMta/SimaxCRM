using System.ComponentModel.DataAnnotations;

namespace SimaxCrm.Model.RequestModel
{
    public class UserLoginModel
    {
        [Required]
        public string Email { get; set; }
        public string OTP { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public int Tid { get; set; }
    }
}