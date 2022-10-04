using Bill_Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.AspNetCore.Authorization;

namespace Bill_Portal.Controllers
{
    [Authorize(Roles ="Admin,Manager,Reader")]
    public class CRUDController : Controller
    {
        private readonly Billing_Portal_Db_CRUD_Context _context;

        public CRUDController(Billing_Portal_Db_CRUD_Context context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,Reader,Manager")]
        
        public async Task<IActionResult> notifications_list()
        {
            return View(await _context.notifications.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.notifications
                .FirstOrDefaultAsync(m => m.notification_id == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public async Task<IActionResult> Create([Bind("notification_id,notification_serial,notification_title,notification_document,description,date")] notification notificationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(notifications_list));
            }
            return View(notificationModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.notifications.FindAsync(id);
            if (transactionModel == null)
            {
                return NotFound();
            }
            return View(transactionModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("notification_id,notification_serial,notification_title,notification_document,description,date")] notification notificationModel)
        {

            if (id != notificationModel.notification_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (notificationModel.notification_id == null)
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
            return View(notificationModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.notifications
                .FirstOrDefaultAsync(m => m.notification_id == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.notifications.FindAsync(id);
            _context.notifications.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
