using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Interfaces
{
    public interface INotificationSender
    {
        NotificationType Type { get; }
        Task SendAsync(string recipient, string message);
    }
}
