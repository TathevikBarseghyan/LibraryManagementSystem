using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.Notification;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

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
            email.From.Add(MailboxAddress.Parse("tathevik.barseghyan@gmail.com"));
            email.To.Add(MailboxAddress.Parse("tathevikbarseghyan@icloud.com"));
            email.Subject = "subject";
            email.Body = new TextPart(TextFormat.Html) { Text = emailNotificationModel.Body };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync("tathevik.barseghyan@gmail.com", "iumpfzcykutpkqps");
            await smtp.SendAsync(email);
            var emailNotification = NotificationMapping.EmailMapToEntity(emailNotificationModel);
            await _notificationRepository.AddEmailAsync(emailNotification);
        }
    }
}
