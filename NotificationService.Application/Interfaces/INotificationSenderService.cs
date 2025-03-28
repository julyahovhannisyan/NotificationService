using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Application.Interfaces
{
    public interface INotificationSenderService
    {
        Task<bool> SendAsync(Notification notification);
    }
}
 