using Bill_Portal.Models;
using Bill_Portal.Services;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Bill_Portal.Repository
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<BillUsers> _userManager;
        private readonly SignInManager<BillUsers> _signInManager;
        private readonly IUserService _userService;

        public AccountRepository(UserManager<BillUsers> userManager, SignInManager<BillUsers> signInManager
            ,IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }
        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new BillUsers()
            {
                Full_Name = userModel.Full_Name,
                Role = userModel.Role,
                RoleId=userModel.RoleId,
                PhoneNumber=userModel.Mobile,
               // Mobile=userModel.Mobile,
                Email = userModel.Email,
                UserName = userModel.Email
            };
            
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

     

        public async Task<SignInResult> PasswordSignInAsync(SignInUserModel signInUserModel)
        {
          var result = await _signInManager.PasswordSignInAsync(signInUserModel.Email,signInUserModel.Password,signInUserModel.RememberMe,false);
          return (result);
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel changePasswordModel)
        {
            var userId= _userService.GetUserId();
            var userid= await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(userid, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
            
        }
    }
}
