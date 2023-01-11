using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Models.Notification;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LybraryManagementSystem.Application.Mappings.Interface;

namespace LybraryManagementSystem.Application.Mappings
{
    public static class NotificationMapping //: INotificationMapping
    {
        //private readonly IOptions<EmailConfiguration> _configuration;
        //private readonly INotificationRepository _notificationRepository;

        //public NotificationMapping(IOptions<EmailConfiguration> configuration, INotificationRepository notificationRepository)
        //{
        //    _configuration = configuration;
        //    _notificationRepository = notificationRepository;
        //}

        public static EmailNotification EmailMapToEntity(EmailNotificationModel emailNotificationModel, string configurationMail)
        {
            if (emailNotificationModel != null)
            {
                return new EmailNotification
                {
                    From= configurationMail,
                    ToEmail = emailNotificationModel.ToEmail,
                    Body = emailNotificationModel.Body,
                    Subject = emailNotificationModel.Subject,
                };
            }

            return null;
        }

        public static EmailNotification ResetPasswordMapToEntity(string toEmail, string url, string configurationMail)
        {
            if (toEmail != null && url != null && configurationMail != null)
            {
                return new EmailNotification
                {
                    From = configurationMail,
                    ToEmail = toEmail,
                    Body = "text" + url + "text",
                    Subject = "ReserPassword",
                };
            }

            return null;
        }

        public static List<EmailNotification> EmailMapToEntityList(List<EmailNotificationModel> emailNotificationModel, string configurationMail)
        {
            return emailNotificationModel.Select(s => EmailMapToEntity(s, configurationMail)).ToList();
        }

        public static List<EmailNotification> AddBookEmailMapToEntity(List<string> emails, string configurationMail)
        {
            //var emails = await _notificationRepository.GetClientEmailsAsync();
            var EmailNotifications = new List<EmailNotification>();

            foreach (var item in emails)
            {
                EmailNotifications.Add(new EmailNotification
                {
                    From = configurationMail,
                    ToEmail = item,
                    Body = "You can check the new book",
                    Subject = "New Book Added",
                });
            }

            return EmailNotifications;
        }

        public static EmailNotificationModel ForgotEmailMapToEntity(string toEmail, string configurationMail)
        {
            if (toEmail != null)
            {
                return new EmailNotificationModel
                {
                    From = configurationMail,
                    ToEmail = toEmail,
                    Body = "You can resset your password here",
                    Subject = "Forgot password",
                };
            }

            return null;
        }

        //public static IdentityModel MapToModel( BellIdentity notification)
        //{
        //    if (notification != null)
        //    {

        //        return new NotificationModel
        //        {
        //            ToEmail = notification.ToEmail,
        //            Body = notification.Body,
        //            Subject = notification.Subject,
        //        };
        //    }
        //    return null;
        //}

    }
}
