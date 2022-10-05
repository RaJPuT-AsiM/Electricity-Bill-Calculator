using Bill_Portal.ViewModels;
using System.Threading.Tasks;

namespace Bill_Portal.Repository
{
    public interface INotificationRepository
    {
        Task<int> AddNewNotification(NotificationViewModel model);
    }
}