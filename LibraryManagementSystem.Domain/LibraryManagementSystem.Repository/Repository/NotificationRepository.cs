using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using MimeKit;
using System.Net.Mail;

namespace LibraryManagementSystem.Repository.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly LibraryDbContext _context;

        public NotificationRepository(LibraryDbContext context)
        {
            _context =  context;
        }

        public async Task AddBellAsync(BellNotification bellNotification)
        {
           await _context.AddAsync(bellNotification);
        }

        
        public async Task AddEmailAsync(EmailNotification emailNotification)
        {
            await _context.AddAsync(emailNotification);
        }

        public Task UpdateBellType(BellNotification bellNotification)
        {
            throw new NotImplementedException();
        }
    }
}
