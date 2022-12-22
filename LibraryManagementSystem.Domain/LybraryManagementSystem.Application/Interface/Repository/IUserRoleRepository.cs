using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IUserRoleRepository
    {
        Task AddAsync(UserRole userRole);
        Task<List<UserRole>> GetAllAsync();
        Task<UserRole> GetByIdAsync(int userRoleId);
        Task DeleteAsync(int userRoleId);

        //Task UpdateAsync(AuthorBook authorBook);
        Task SaveChangesAsync();
    }
}
