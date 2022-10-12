using Bill_Portal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.AspNetCore.Authorization;
using Bill_Portal.Repository;
using Bill_Portal.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;

namespace Bill_Portal.Controllers
{
    [Authorize(Roles = "Admin,Manager,Reader")]
    public class CRUDController : Controller
    {
        private readonly Billing_Portal_Db_CRUD_Context _context;

        private readonly NotificationRepository _notificationRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CRUDController(Billing_Portal_Db_CRUD_Context context,
            NotificationRepository notificationRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _notificationRepository = notificationRepository;
            _webHostEnvironment = webHostEnvironment;
            _context = context;

        }
        //Getting All Notifications
        [Authorize(Roles = "Admin,Reader,Manager")]
        public async Task<IActionResult> notifications_list()
        {
            var notifyList = await _notificationRepository.GetAllNotificatinos();
            return View(notifyList);
            //return View(await _context.notifications.ToListAsync());
        }
        //Adding New Notifications
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationViewModel notificationViewModel)
        {
            if (ModelState.IsValid)
            {
                if (notificationViewModel.notification_image != null)
                {
                    string folder = "documents/images/notifications/";
                    folder += Guid.NewGuid().ToString() + "_" + notificationViewModel.notification_image.FileName;
                    notificationViewModel.notification_image_url = "/" + folder;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    await notificationViewModel.notification_image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                    
                    //notificationViewModel.notification_image = await UploadImage(folder, notificationViewModel.notification_image);
                }
                //int id = await _notificationRepository.AddNewNotification(notificationViewModel);
                //if (id > 0)
                //{
                //    return RedirectToAction("NotificationDetails");
                //}
            }
            return View();
        }

    }
}
