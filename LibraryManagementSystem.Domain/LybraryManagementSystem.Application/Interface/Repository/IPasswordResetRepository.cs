using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IPasswordResetRepository
    {
        Task AddAsync(PasswordReset passwordReset);
        Task<PasswordReset> GetByGuId(string id);
        Task ResetPasswordAsync(User user);
    }
}
