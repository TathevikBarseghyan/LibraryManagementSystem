using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        List<User> GetAll();
        User GetById(int userId);
        Task<User> GetByUserNameOrEmail(string username, string email);
        User Delete(int userId);
        void Update(User user);
        Task SaveChangesAsync();
    }
}
