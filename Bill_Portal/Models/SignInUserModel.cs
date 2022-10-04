using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.Models
{
    public class SignInUserModel
    {
        [Required(ErrorMessage ="*")]
        [EmailAddress(ErrorMessage ="Incorrect Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
