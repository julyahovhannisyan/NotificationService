using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public NotificationType Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
