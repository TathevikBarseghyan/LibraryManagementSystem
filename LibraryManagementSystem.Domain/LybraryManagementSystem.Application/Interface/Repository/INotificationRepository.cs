using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface INotificationRepository
    {
        Task AddEmailAsync(EmailNotification emailNotification);
        //Task UpdateEmailStatus(EmailNotification emailNotification);
        
        Task AddBellAsync(BellNotification bellNotification);
        Task UpdateBellType(BellNotification bellNotification);
    }
}
