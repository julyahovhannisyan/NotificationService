using NotificationService.Domain.Enums;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Application.Interfaces
{
    public interface INotificationFactory
    {
        INotificationSender CreateNotificationSender(NotificationType type);
    }
}
