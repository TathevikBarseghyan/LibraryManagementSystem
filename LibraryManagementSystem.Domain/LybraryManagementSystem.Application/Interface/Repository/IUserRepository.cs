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
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByUserName(string username);
        Task DeleteAsync(int userId);
        Task UpdateAsync(User user);
        Task SaveChangesAsync();
    }
}
