using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Notification;
using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IIdentityService
    {
        string GenerateGuId();
        //Task AddEmailNotificationAsync(string toEmail);
        //Task AddPasswordResetAsync(string email, string guid);
        Task ForgotPasswordAsync(string email);

    }
}
