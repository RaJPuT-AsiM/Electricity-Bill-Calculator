using Microsoft.AspNetCore.Identity;

namespace Bill_Portal.Models
{
    public class BillUsers:IdentityUser
    {
        public string Full_Name { get; set; }
    }
}
