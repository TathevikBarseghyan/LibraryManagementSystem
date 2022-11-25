using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IUserService 
    {
        Task AddAsync(AddModel user);
        List<UserModel> GetAll();
        UserModel GetById(int userId);
        Task<UserModel> GetByUserNameOrEmail(string username, string email);
        UserModel Delete(int userId);
        void Update(UserModel user);
        Task SaveChangesAsync();
        bool ValidateUser(UserModel user, LogInModel logInModel);
        string GenerateToken(LogInModel logInModel);
    }
}
