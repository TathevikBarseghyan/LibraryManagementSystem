using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.ResponseModel;
using LybraryManagementSystem.Application.Models.User;
using LybraryManagementSystem.Application.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IUserService 
    {
        Task<OperationResultModel> LogInAsync(LogInModel userModel);
        Task AddAsync(AddUserModel user);
        Task<List<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(int userId);
        Task<UserModel> GetByUserName(string username);
        Task<UserRoleModel> GetRoleByUserNameAsync(string username);
        Task DeleteAsync(int userId);
        Task UpdateAsync(UserModel userModel);
        Task SaveChangesAsync();
        Task<User> GetByEmailAsync(string email);
    }
}
