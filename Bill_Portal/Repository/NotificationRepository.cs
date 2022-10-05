﻿using Bill_Portal.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Bill_Portal.ViewModels;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Bill_Portal.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly Billing_Portal_Db_CRUD_Context _crud_Context;

        public NotificationRepository(Billing_Portal_Db_CRUD_Context crud_context)
        {
            _crud_Context = crud_context;
        }
        //Adding New Notification
        public async Task<int> AddNewNotification(NotificationViewModel model)
        {
            var newNotification = new notification()
            {
                notification_serial = model.notification_serial,
                notification_title = model.notification_title,
                notification_document = model.notification_image_url,
                notification_id = model.notification_id,
                date = model.date,

            };

            await _crud_Context.notifications.AddAsync(newNotification);
            await _crud_Context.SaveChangesAsync();

            return newNotification.notification_id;
        }
        //Getting All Notifications
        public async Task<List<NotificationViewModel>> GetAllNotificatinos()
        {
            return await _crud_Context.notifications.Select(notify => new NotificationViewModel()
                  {
                      notification_serial = notify.notification_serial,
                      notification_image_url = notify.notification_document,
                      notification_title = notify.notification_title,
                      date = notify.date,
                  }).ToListAsync();
        }
        //Updating Notification

        //Deleting Notification
    }
}
