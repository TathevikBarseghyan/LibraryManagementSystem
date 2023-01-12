using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class PasswordResetService : IPasswordResetService
    {
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly IUserService _userService;
        public PasswordResetService(IPasswordResetRepository passwordResetRepository, IUserService userService)
        {
            _passwordResetRepository = passwordResetRepository;
            _userService = userService;
        }

        //public async Task AddAsync(PasswordResetModel passwordResetModel)
        //{
        //    var passwordReset = PasswordResetMappings.MapToEntity(passwordResetModel);
        //    await _passwordResetRepository.AddAsync(passwordReset);
        //}

        public async Task AddAsync(int userId, string guId)
        {
            var passwordReset = PasswordResetMappings.MapToEntity(userId, guId);
            await _passwordResetRepository.AddAsync(passwordReset);
        }

        public async Task ResetPasswordAsync(PasswordResetModel passwordResetModel, string guId)
        {
            var userModel = await _passwordResetRepository.GetByGuId(guId);

            if (userModel != null)
            {
                var user = PasswordResetMappings.MapToUserEntity(passwordResetModel, userModel.UserId);
                await _passwordResetRepository.ResetPasswordAsync(user);
            }
        }
    }
}
