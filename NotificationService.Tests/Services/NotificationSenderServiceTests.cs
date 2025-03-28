using Xunit;
using Moq;
using NotificationService.Application.Services;
using NotificationService.Domain.Interfaces;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Application.Interfaces;

public class NotificationSenderServiceTests
{
    private readonly Mock<INotificationFactory> _mockFactory;
    private readonly Mock<INotificationRepository> _mockRepository;
    private readonly Mock<INotificationSender> _mockSender;
    private readonly NotificationSenderService _service;

    public NotificationSenderServiceTests()
    {
        _mockFactory = new Mock<INotificationFactory>();
        _mockRepository = new Mock<INotificationRepository>();
        _mockSender = new Mock<INotificationSender>();

        _service = new NotificationSenderService(_mockFactory.Object, _mockRepository.Object);
    }

    [Fact]
    public async Task SendAsync_ValidNotification_ShouldCallSenderAndSave()
    {
        var notification = new Notification
        {
            Type = NotificationType.Email,
            Recipient = "test@example.com",
            Message = "Hello"
        };

        _mockFactory.Setup(f => f.CreateNotificationSender(notification.Type))
                    .Returns(_mockSender.Object);

        _mockSender.Setup(s => s.SendAsync(notification.Recipient, notification.Message))
                   .Returns(Task.CompletedTask);

        _mockRepository.Setup(r => r.AddNotificationAsync(notification))
                       .Returns(Task.CompletedTask);

        var result = await _service.SendAsync(notification);

        Assert.True(result);
        _mockSender.Verify(s => s.SendAsync(notification.Recipient, notification.Message), Times.Once);
        _mockRepository.Verify(r => r.AddNotificationAsync(notification), Times.Once);
    }

    [Fact]
    public async Task SendAsync_InvalidNotificationType_ShouldThrowException()
    {
        var notification = new Notification
        {
            Type = (NotificationType)999,
            Recipient = "test@example.com",
            Message = "Hello"
        };

        _mockFactory.Setup(f => f.CreateNotificationSender(notification.Type))
                    .Returns((INotificationSender)null);
        await Assert.ThrowsAsync<ArgumentException>(() => _service.SendAsync(notification));
    }
}

