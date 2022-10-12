using Bill_Portal.Models;
using Bill_Portal.ViewModels;
using System.Threading.Tasks;

namespace Bill_Portal.Repository
{
    public interface INotificationRepository
    {
        notification GetNotification(int? id);
        notification Add(notification notification);
    }
}