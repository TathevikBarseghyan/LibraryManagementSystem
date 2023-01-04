using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enumerations;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Models.Notification;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;

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

        
        public async Task AddEmailNotificationsAsync(List<EmailNotification> emailNotifications)
        {
             await _context.EmailNotifications.AddRangeAsync(emailNotifications);
             await _context.SaveChangesAsync();
        }

        public async Task<List<string>> GetClientEmailsAsync()
        {
            var emails = await _context.Users.Where(u => u.UserRoles.Any(w => w.RoleId == (int) RoleType.Client))
                .Select(u => u.Email).ToListAsync();

            return emails;
        }
            
    

        public Task UpdateBellType(BellNotification bellNotification)
        {
            throw new NotImplementedException();
        }
    }
}
