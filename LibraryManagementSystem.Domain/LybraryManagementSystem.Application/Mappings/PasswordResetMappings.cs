using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Helper;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class PasswordResetMappings
    {
        //private  readonly IUserService _userService;
        //public PasswordResetMappings(IUserService userService)
        //{
        //    _userService = userService;
        //}
        public static User MapToUserEntity(PasswordResetModel passwordResetModel, int userId)
        {
            var computedSalt = IdentityHelper.GetSalt();
            var computedHash = IdentityHelper.GetHash(passwordResetModel.Password, computedSalt);

            return new User
            {
                Id = userId,
                Hash = computedHash,
                Salt = Convert.ToBase64String(computedSalt),
            };
        }

        public static PasswordReset MapToEntity(int userId, string guId)
        {
            return new PasswordReset
            {
                UserId = userId,
                Date = DateTime.Now,
                GuId = guId,

            };
        }
    }
}
