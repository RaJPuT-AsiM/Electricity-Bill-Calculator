using Bill_Portal.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Bill_Portal.ViewModels;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace Bill_Portal.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly Billing_Portal_Db_CRUD_Context _crud_Context;

        public NotificationRepository(Billing_Portal_Db_CRUD_Context crud_context)
        {
            _crud_Context = crud_context;
        }
        //Getting All Notifications
        public async Task<List<NotificationViewModel>> GetAllNotificatinos()
        {
            return await _crud_Context.notifications.Select(notify => new NotificationViewModel()
            {
                notification_id = notify.notification_id,
                notification_serial = notify.notification_serial,
                notification_image_url = notify.notification_document,
                description = notify.description,
                notification_title = notify.notification_title,
                date = notify.date,
            }).ToListAsync();
        }

        //Add New Notification
        public notification Add(notification notification)
        {
            _crud_Context.notifications.Add(notification);
            _crud_Context.SaveChanges();
            return notification;
        }

        // Get Details of Notification for update and details
        public notification GetNotification(int? id)
        {
            return _crud_Context.notifications.Find(id);
        }       

        //Updating Notification
        public notification Update(notification newNotification)
        {
            var notify = _crud_Context.notifications.Attach(newNotification);
            notify.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _crud_Context.SaveChanges();
            return newNotification;
        }

        //Deleting Notification

 


    }
}
