using System.ComponentModel.DataAnnotations;

namespace Bill_Portal.ViewModels
{
    public class CreateRoleViewModels
    {
        [Required(ErrorMessage ="*")]
        public string RoleNames { get; set; }
    }
}
