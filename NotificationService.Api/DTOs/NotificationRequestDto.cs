using NotificationService.Domain.Enums;

namespace NotificationService.Api.Models
{
    public class NotificationRequestDto
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}

