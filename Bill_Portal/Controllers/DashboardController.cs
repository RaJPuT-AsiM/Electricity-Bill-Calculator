using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bill_Portal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Bill_Portal.Controllers
{
    [Authorize]
    public class Dashboard : Controller
    {
        private readonly Billing_Portal_Db_CRUD_Context _context;

        public Dashboard(Billing_Portal_Db_CRUD_Context context)
        {
            _context = context;
        }

        // GET: TransactionModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.AspNetUsers.ToListAsync());
        }

        //GET: TransactionModels/Details/5
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

        //GET: TransactionModels/Create
        public IActionResult Create()
        {
            return View();
        }
        
        //POST: TransactionModels/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")] AspNetUsers transactionModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactionModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactionModel);
        }

        //// GET: TransactionModels/Edit/5
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

        //// POST: TransactionModels/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email,PhoneNumber,FullName,Role,,UserName,NormalizedUserName,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,RoleId")] AspNetUsers transactionModel)
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

        //// GET: TransactionModels/Delete/5
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

        //private bool TransactionModelExists(int id)
        //{
        //    return _context.AspNetUsers.Any(e => e.Id == id);
        //}
    }
}
