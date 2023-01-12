using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.Notification;
using LybraryManagementSystem.Application.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly INotificationService _notificationService;
        private readonly IPasswordResetService _passwordResetService;
        private readonly IUserService _userService;
        private readonly IOptions<EmailConfiguration> _configuration;


        public IdentityService(INotificationService notificationService,
            IPasswordResetService passwordResetService,
            IUserService userService,
            IOptions<EmailConfiguration> configuration)
        {
            _notificationService = notificationService;
            _passwordResetService = passwordResetService;
            _userService = userService;
            _configuration = configuration;
        }

        public string GenerateGuId()
        {
            var guid = Guid.NewGuid();
            return  $"https://localhost:7204/api/Notification/reset-pass?{guid}";
        }

        //public async Task AddEmailNotificationAsync(string toEmail)
        //{
        //    var emailNotificationModel = NotificationMapping.ForgotEmailMapToEntity(toEmail, _configuration.Value.Email);
        //    await _notificationService.AddEmailNotificationsAsync(new List<EmailNotificationModel>() { emailNotificationModel });
        //}

        //public async Task AddPasswordResetAsync(string email, string guid)
        //{
        //    var user = await _userService.GetByEmailAsync(email);
        //    var passwordResetModel = new PasswordResetModel
        //    {
        //        UserId = user.Id,
        //        Date = DateTime.Now,
        //        GuId = guid
        //    };
        //    await _passwordResetService.AddAsync(passwordResetModel);
        //}

        public async Task ForgotPasswordAsync(string email)
        {
            var userInfo = await _userService.GetByEmailAsync(email);
            if (userInfo != null)
            {
                var guid = Guid.NewGuid();
                var url = $"https://localhost:7204/api/Notification/reset-pass?guid={guid}"; 

                await _notificationService.ForgotEmailAsync(email, url);
                await _notificationService.AddEmailNotificationAsync(email, url);
                await _passwordResetService.AddAsync(userInfo.Id, guid.ToString());
            }
        }

    }
}
