using Bill_Portal.Models;
using Bill_Portal.Repository;
using Bill_Portal.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bill_Portal.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserService _userService;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
      
        }

        // Sing Up
        [HttpGet]
        public IActionResult SignUpUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUpUser(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
                ViewBag.Message = "Sign Up Successfull";
                
            }
            return View();
        }

        // Login
        //[Route("login")]
        [HttpGet]
        public IActionResult SignInUser()
        {
            return View();
        }

        //[Route("login")]    
        [HttpPost]
        public async Task<IActionResult> SignInUser(SignInUserModel signInUserModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInUserModel);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    else
                        return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect Email or Password");
            }
            return View(signInUserModel);
        }

        // Logout
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // ChangePassword
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePasswordAsync(changePasswordModel);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(changePasswordModel);
        }
    }
}