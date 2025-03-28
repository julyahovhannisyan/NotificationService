using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Interfaces;

namespace NotificationService.Infrastructure.Data
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationServiceDbContext _dbContext;

        public NotificationRepository(NotificationServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddNotificationAsync(Notification notification)
        {
            _dbContext.Notifications.Add(notification);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Notification> GetAllNotifications()
        {
            return _dbContext.Notifications.AsNoTracking();
        }

        public async Task<Notification?> GetNotificationByIdAsync(int id)
        {
            return await _dbContext.Notifications
                .AsNoTracking()
                .FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
