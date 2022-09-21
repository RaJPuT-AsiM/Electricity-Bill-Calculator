using Bill_Portal.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Bill_Portal.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInUserModel signInUserModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel); 
    }
}