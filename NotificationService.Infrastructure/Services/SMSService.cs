using NotificationService.Domain.Enums;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Infrastructure.Services
{
    public class SMSSender : INotificationSender
    {
        public NotificationType Type => NotificationType.SMS;

        public async Task SendAsync(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
            await Task.CompletedTask;
        }
    }
}