﻿using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface INotificationRepository
    {
        Task AddEmailNotificationListAsync(List<EmailNotification> emailNotifications);
        Task AddEmailNotificationAsync(EmailNotification emailNotification);
        //Task UpdateEmailStatus(EmailNotification emailNotification);
        Task<List<string>> GetClientEmailsAsync();
        Task AddBellAsync(BellNotification bellNotification);
        Task UpdateBellType(BellNotification bellNotification);
    }
}
