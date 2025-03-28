using NotificationService.Domain.Enums;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Infrastructure.Services
{
    public class EmailSender : INotificationSender
    {
        public NotificationType Type => NotificationType.Email;

        public async Task SendAsync(string recipient, string message)
        {
            Console.WriteLine($"Sending Email to {recipient}: {message}");
            await Task.CompletedTask;
        }
    }
}
