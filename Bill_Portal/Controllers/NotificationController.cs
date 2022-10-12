using Bill_Portal.Models;
using Bill_Portal.Repository;
using Bill_Portal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace Bill_Portal.Controllers
{
    [Authorize(Roles = "Admin,Manager,Reader")]
    public class NotificationController : Controller
    {
        private readonly NotificationRepository _notificationRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Billing_Portal_Db_CRUD_Context _context;

        public NotificationController(NotificationRepository notificationRepository, IWebHostEnvironment webHostEnvironment,Billing_Portal_Db_CRUD_Context context)
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

        //Adding New Notification
        [Authorize(Roles = "Admin,Manager")]
        [HttpGet]
        public ViewResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNotification(NotificationViewModel notificationViewModel)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(notificationViewModel);

                notification newNotification = new notification
                {
                    notification_serial = notificationViewModel.notification_serial,
                    notification_title = notificationViewModel.notification_title,
                    notification_document = uniqueFileName,
                    date = notificationViewModel.date,
                    description = notificationViewModel.description
                };
                _notificationRepository.Add(newNotification);
                return RedirectToAction("notifications_list");
            }
            return View();
        }

        //Details of Notifications
        //public IActionResult NotificationDetails(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var notificationModel = _context.notifications.FirstOrDefaultAsync(m => m.notification_id == id);
        //    //notification notification = _notificationRepository.GetNotification(id);

        //    if (notificationModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(notificationModel);
        //}
        public IActionResult NotificationDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var notificationModel = _context.notifications.FirstOrDefaultAsync(m => m.notification_id == id);
            var notificationModel = _notificationRepository.GetNotification(id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            return View(notificationModel);
        }
        //Edit Notification
        [HttpGet]
        public IActionResult EditNotification(int? id)
        {
            notification editNotification = _notificationRepository.GetNotification(id);
            if(editNotification != null)
            {
                NotificationEditViewModel notificationEditViewModel = new NotificationEditViewModel
                {
                    notification_serial = editNotification.notification_serial,
                    date = editNotification.date,
                    description = editNotification.description,
                    notification_title = editNotification.notification_title,
                    notification_ExistingPhotoPath = editNotification.notification_document
                };
                return View(notificationEditViewModel);
            }
            return View();
        }
        [HttpPost]
        public IActionResult EditNotification(NotificationEditViewModel notificationEditViewModel)
        {
            if (ModelState.IsValid)
            {
                notification notification = _notificationRepository.GetNotification(notificationEditViewModel.Id);
                if (notificationEditViewModel.notification_image != null)
                {
                    if (notificationEditViewModel.notification_ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath +
                            "/documents/images/notifications/" + notificationEditViewModel.notification_ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }                    
                    notification.date = notificationEditViewModel.date;
                    notification.notification_title = notificationEditViewModel.notification_title;
                    notification.notification_serial = notificationEditViewModel.notification_serial;
                    notification.description = notificationEditViewModel.description;
                    notification.notification_document = ProcessUploadedFile(notificationEditViewModel);
                }
                notification updatedNotification = _notificationRepository.Update(notification);
                return RedirectToAction("notifications_list");
            }

            if (notificationEditViewModel.date != null && notificationEditViewModel.notification_serial != null && 
                    notificationEditViewModel.notification_title != null && notificationEditViewModel.description != null)
            {
                notification notification = _notificationRepository.GetNotification(notificationEditViewModel.Id);
                if (notificationEditViewModel.notification_image == null)
                {
                    notification.date = notificationEditViewModel.date;
                    notification.notification_title = notificationEditViewModel.notification_title;
                    notification.notification_serial = notificationEditViewModel.notification_serial;
                    notification.description = notificationEditViewModel.description;
                    notification.notification_document = notificationEditViewModel.notification_ExistingPhotoPath;
                }
                notification updatedNotification = _notificationRepository.Update(notification);
                return RedirectToAction("notifications_list");
            }
            return View(notificationEditViewModel);
        }

        //Uploading Notification Image
        private string ProcessUploadedFile(NotificationViewModel notificationViewModel)
        {
            string uniqueFileName = null;

            if (notificationViewModel.notification_image != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath + "/documents/images/notifications/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + notificationViewModel.notification_image.FileName;
                string filePath = Path.Combine(uploadsFolder + uniqueFileName);
                using (var fileStream = new FileStream(filePath , FileMode.Create))
                {
                    notificationViewModel.notification_image.CopyTo(fileStream);
                }
            }
            uniqueFileName = "/documents/images/notifications/"+uniqueFileName;
            return uniqueFileName;
        }
    }
}
