using NotificationService.Domain.Enums;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Infrastructure.Services
{
    public class PushSender : INotificationSender
    {
        public NotificationType Type => NotificationType.Push;

        public async Task SendAsync(string recipient, string message)
        {
            Console.WriteLine($"Sending Push Notification to {recipient}: {message}");
            await Task.CompletedTask;
        }
    }
}
