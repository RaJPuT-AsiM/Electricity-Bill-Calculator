using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bill_Portal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Azure.Amqp.Framing;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Identity;
using Bill_Portal.Repository;
using Microsoft.Extensions.Logging;
using Bill_Portal.Services;

namespace Bill_Portal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Dashboard : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BillUsers> _userManager;
        private readonly Billing_Portal_Db_CRUD_Context _context;
        public Dashboard(Billing_Portal_Db_CRUD_Context context,
            RoleManager<IdentityRole> roleManager,
            UserManager<BillUsers> userManager
            )
        {            
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;            
        }

        // Get with sorting
        public IActionResult Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            ViewData["RoleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "role_desc" : "";

            var employees = from e in _context.AspNetUsers select e;
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(e => e.FullName);
                    break;
                default:
                    employees = employees.OrderBy(e => e.FullName);
                    break;

            }
            return View(employees);
        }
             
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var transactionModel = await _context.AspNetUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (transactionModel == null)
            {
                return NotFound();
            }
            return View(transactionModel);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.AspNetUsers.FindAsync(id);
            if (transactionModel == null)
            {
                return NotFound();
            }
            return View(transactionModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,PhoneNumber,FullName,UserName,NormalizedUserName,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUsers transactionModel)
        {
            if (id != transactionModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(transactionModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (transactionModel == null)

                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(transactionModel);
        }

        ////public async Task<IActionResult> Delete(int? id)
        ////{
        ////    if (id == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    var transactionModel = await _context.AspNetUsers
        ////        .FirstOrDefaultAsync(m => m.Id == id);
        ////    if (transactionModel == null)
        ////    {
        ////        return NotFound();
        ////    }

        ////    return View(transactionModel);
        ////}

        //// POST: TransactionModels/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var transactionModel = await _context.AspNetUsers.FindAsync(id);
        //    _context.AspNetUsers.Remove(transactionModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}


        //public async Task<IActionResult> AssignRole(string? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userrolemodel = await _context.AspNetUsers.FindAsync(id);
        //    if (userrolemodel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userrolemodel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AssignRole(string id, [Bind("UserId,RoleId")] AspNetUserRoles userRoleModel, AspNetUsers usersModel)
        //{
        //    if (id != usersModel.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Add(userRoleModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (userRoleModel == null)
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userRoleModel);
        //}


        // Sing Up
        //[HttpGet]
        //public IActionResult AssignRole()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AssignRole(AspNetUserRoles userModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _adminRepository.CreateUserRole(userModel, asiii);
        //        if (!result.Succeeded)
        //        {
        //            foreach (var errorMessage in result.Errors)
        //            {
        //                ModelState.AddModelError("", errorMessage.Description);
        //            }
        //            return View(userModel);
        //        }
        //        ModelState.Clear();
        //        //ViewBag.Message = "Sign Up Successfull";
        //    }
        //    return View();
        //}

        //Manage User Roles

        [HttpGet]
        
        public async Task<IActionResult> ManageUserRoles(string? id, string? name)
        {
            ViewBag.userName = name;
            ViewBag.userId = id;

            var user = await _userManager.FindByIdAsync(id);
            

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in _roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string? id)
        {            
            var user = await _userManager.FindByIdAsync(id);            

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }

            var roles = await _userManager.GetRolesAsync(user);
            TempData["roleing"] = roles;
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("Index", new { Id = id });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View("ListUsers");
            }
        }
    }
}
