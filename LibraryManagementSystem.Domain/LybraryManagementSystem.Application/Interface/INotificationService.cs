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

    }
}
