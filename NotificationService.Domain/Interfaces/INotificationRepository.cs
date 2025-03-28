using NotificationService.Domain.Entities;

namespace NotificationService.Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task AddNotificationAsync(Notification notification);
        IQueryable<Notification> GetAllNotifications();
        Task<Notification?> GetNotificationByIdAsync(int id);
    }
}
