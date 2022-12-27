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
        public static Notification MapToEntity(NotificationModel notificationModel)
        {
            if (notificationModel != null)
            {
                return new Notification
                {
                    ToEmail = notificationModel.ToEmail,
                    Body = notificationModel.Body,
                    Subject = notificationModel.Subject,
                };
            }

            return null; 
        }

        public static NotificationModel MapToModel( Notification notification)
        {
            if (notification != null)
            {

                return new NotificationModel
                {
                    ToEmail = notification.ToEmail,
                    Body = notification.Body,
                    Subject = notification.Subject,
                };
            }
            return null;
        }

    }
}
