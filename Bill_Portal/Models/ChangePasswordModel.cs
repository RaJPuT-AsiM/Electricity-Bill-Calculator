﻿using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="Required")]
        [DataType(DataType.Password)]
        [Display(Name="Current Password")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword",ErrorMessage ="Password Not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
