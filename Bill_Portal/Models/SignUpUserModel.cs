using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.Models
{
    public class SignUpUserModel
    {
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "Name")]
        public string Full_Name { get; set; }
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mobile No.")]
        public string Mobile { get; set; }

        
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password not Matched.")]
        public string ConfirmPassword { get; set; }
    }
}
