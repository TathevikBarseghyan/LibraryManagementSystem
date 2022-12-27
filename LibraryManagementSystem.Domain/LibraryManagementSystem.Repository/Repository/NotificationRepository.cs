using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using MimeKit;
using System.Net.Mail;

namespace LibraryManagementSystem.Repository.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly EmailConfiguration _emailConfiduration;

        public NotificationRepository(EmailConfiguration emailConfiduration)
        {
            _emailConfiduration = emailConfiduration;
        }

        public async Task SendEmailAsync(Notification notification)
        {
            var email = new MailMessage();
            email.From = new MailAddress(_emailConfiduration.From);
            email.To.Add(new MailAddress(notification.ToEmail));
            email.Subject = "subject";
            email.Body = "Body";

            var smtp = new SmtpClient();
            await smtp.SendMailAsync(email);
        }
    }
}
