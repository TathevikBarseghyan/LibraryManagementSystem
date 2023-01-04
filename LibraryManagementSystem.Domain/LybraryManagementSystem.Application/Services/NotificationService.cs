using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Mappings.Interface;
using LybraryManagementSystem.Application.Models.Book;
using LybraryManagementSystem.Application.Models.Notification;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using MimeKit;
using MimeKit.Text;

namespace LybraryManagementSystem.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        //private readonly INotificationMapping _notificationMapping;
        private readonly IOptions<EmailConfiguration> _configuration;

        public NotificationService(INotificationRepository notificationRepository, 
            IOptions<EmailConfiguration> configuration)
            //INotificationMapping notificationMapping)
        {
            _notificationRepository = notificationRepository;
            _configuration = configuration;
            //_notificationMapping = notificationMapping;
        }

        public async Task SendEmailAsync(EmailNotificationModel emailNotificationModel)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.Value.Email));
            email.To.Add(MailboxAddress.Parse(emailNotificationModel.ToEmail));
            email.Subject = emailNotificationModel.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailNotificationModel.Body };

            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_configuration.Value.Host, _configuration.Value.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration.Value.Email, _configuration.Value.Password);
                await smtp.SendAsync(email);
            }
            var emailNotification = NotificationMapping.EmailMapToEntity(emailNotificationModel, _configuration.Value.Email);
            await _notificationRepository.AddEmailNotificationsAsync(new List<EmailNotification>() { emailNotification });
        }

        public async Task AddingBookEmailAsync()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.Value.Email));

            var toEmail = await _notificationRepository.GetClientEmailsAsync();

            email.To.AddRange(toEmail.Select(s => MailboxAddress.Parse(s)));
            email.Subject = "New book is available";
            email.Body = new TextPart(TextFormat.Html) { Text = "You can check the new book" };
            
            using (var smtp = new SmtpClient())
            {
                await smtp.ConnectAsync(_configuration.Value.Host, _configuration.Value.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration.Value.Email, _configuration.Value.Password);
                await smtp.SendAsync(email);
                var emailNotification = NotificationMapping.AddBookEmailMapToEntity(toEmail, _configuration.Value.Email);
                await _notificationRepository.AddEmailNotificationsAsync(emailNotification);
            }
        }

        public async Task<List<string>> GetClientEmailsAsync()
        {
            return await _notificationRepository.GetClientEmailsAsync();
        }
    }
}
