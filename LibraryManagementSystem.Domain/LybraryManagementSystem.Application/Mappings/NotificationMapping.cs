using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class NotificationMapping
    {
        public static EmailNotification EmailMapToEntity(EmailNotificationModel emailNotificationModel)
        {
            if (emailNotificationModel != null)
            {
                return new EmailNotification
                {
                    From= emailNotificationModel.From,
                    ToEmail = emailNotificationModel.ToEmail,
                    Body = emailNotificationModel.Body,
                    Subject = emailNotificationModel.Subject,
                };
            }

            return null;
        }

        //public static NotificationModel MapToModel( BellNotification notification)
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
