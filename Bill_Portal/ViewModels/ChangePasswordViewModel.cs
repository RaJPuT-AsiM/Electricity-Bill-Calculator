using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage ="*")]
        [DataType(DataType.Password)]
        [Display(Name="Current Password")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword",ErrorMessage ="Password Not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
