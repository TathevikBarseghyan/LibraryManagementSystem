using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface INotificationService
    {
        Task SendEmailAsync(EmailNotificationModel notificationModel);
        Task AddEmailNotificationListAsync(List<EmailNotificationModel> emailNotificationModel);
        Task AddEmailNotificationAsync(string email, string url);
        Task AddingBookEmailAsync();
        Task ForgotEmailAsync(string email, string url, User userInfo);
        Task<List<string>> GetClientEmailsAsync();
    }
}
