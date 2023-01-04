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

namespace LybraryManagementSystem.Application.Mappings.Interface
{
    public interface INotificationMapping
    {
        EmailNotification EmailMapToEntity(EmailNotificationModel emailNotificationModel);

        List<EmailNotification> AddBookEmailMapToEntity(List<string> emails);
    }
}
