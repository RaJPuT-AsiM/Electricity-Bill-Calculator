using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System.Security.Permissions;

namespace Bill_Portal.ViewModels
{
    public class NotificationEditViewModel : NotificationViewModel
    {
        public int Id { get; set; }
        public string notification_ExistingPhotoPath { get; set; }
    }
}
