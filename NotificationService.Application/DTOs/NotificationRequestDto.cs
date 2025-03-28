using NotificationService.Domain.Enums;

namespace NotificationService.Application.DTOs
{
    public class NotificationRequestDto
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
