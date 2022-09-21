using Microsoft.AspNetCore.Identity;

namespace Bill_Portal.Models
{
    public class BillUsers:IdentityUser
    {
        public string Full_Name { get; set; }
        public string Role { get; set; }
        public string RoleId { get; set; }
    }
}
