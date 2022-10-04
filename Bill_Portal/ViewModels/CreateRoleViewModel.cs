using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage ="*")]
        public string RoleName { get; set; }
    }
}
