using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IPasswordResetService 
    {
        //Task AddAsync(PasswordResetModel passwordResetModel);
        Task ResetPasswordAsync(PasswordResetModel passwordResetModel, string guId);
        Task AddAsync(int userId, string guId);
    }
}
