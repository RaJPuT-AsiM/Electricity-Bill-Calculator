using Bill_Portal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bill_Portal.Helpers
{
    public class BillUserClaimsPricipalFactory : UserClaimsPrincipalFactory<BillUsers,IdentityRole>
    {
        public BillUserClaimsPricipalFactory(UserManager<BillUsers> userManager, 
            RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> option)
            : base(userManager, roleManager, option)    
        {
        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(BillUsers user)
        {
            var identity= await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("UserFullName", user.Full_Name ?? ""));
            return identity;
        }

    }
}
