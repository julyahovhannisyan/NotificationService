using NotificationService.Application.Interfaces;
using NotificationService.Domain.Enums;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Application.Factories
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly Dictionary<NotificationType, INotificationSender> _senders;

        public NotificationFactory(IEnumerable<INotificationSender> senders)
        {
            _senders = senders.ToDictionary(s => s.Type);
        }

        public INotificationSender CreateNotificationSender(NotificationType type)
        {
            if (_senders.TryGetValue(type, out var sender))
            {
                return sender;
            }

            throw new ArgumentException($"Invalid notification type: {type}", nameof(type));
        }
    }
}
