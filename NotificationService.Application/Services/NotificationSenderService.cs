using NotificationService.Application.Interfaces;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Application.Services;

public class NotificationSenderService : INotificationSenderService
{
    private readonly INotificationFactory _notificationFactory;
    private readonly INotificationRepository _notificationRepository;

    public NotificationSenderService(
        INotificationFactory notificationFactory,
        INotificationRepository notificationRepository)
    {
        _notificationFactory = notificationFactory;
        _notificationRepository = notificationRepository;
    }

    public async Task<bool> SendAsync(Notification notification)
    {
        var sender = _notificationFactory.CreateNotificationSender(notification.Type);

        if (sender == null)
        {
            throw new ArgumentException("Invalid notification type.");
        }

        await sender.SendAsync(notification.Recipient, notification.Message);

        await _notificationRepository.AddNotificationAsync(notification);

        return true;
    }
}
