using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.Notification;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace LybraryManagementSystem.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }


        public async Task SendEmailAsync(EmailNotificationModel emailNotificationModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("emanuel.parisian@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("emanuel.parisian@ethereal.email"));
            email.Subject = "subject";
            email.Body = new TextPart("test body");

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("emanuel.parisian@ethereal.email", "T28v8HNJ79uW5E7Shg");
            await smtp.SendAsync(email);
            var emailNotification = NotificationMapping.EmailMapToEntity(emailNotificationModel);
            await _notificationRepository.AddEmailAsync(emailNotification);
        }
    }
}
