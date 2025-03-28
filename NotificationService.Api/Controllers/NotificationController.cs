using Microsoft.AspNetCore.Mvc;
using NotificationService.Api.Models;
using NotificationService.Application.Services;
using NotificationService.Domain.Entities;

namespace NotificationService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly NotificationSenderService _sendNotificationService;

        public NotificationController(NotificationSenderService sendNotificationService)
        {
            _sendNotificationService = sendNotificationService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequestDto notificationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var notification = new Notification
            {
                Message = notificationRequest.Message,
                Type = notificationRequest.Type,
                Recipient = notificationRequest.Recipient,
                SentAt = DateTime.UtcNow
            };

            var result = await _sendNotificationService.SendAsync(notification);

            if (result)
            {
                return Ok("Notification sent successfully.");
            }

            return BadRequest("Failed to send notification.");
        }
    }
}
