using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly LibraryDbContext _context;

        public UserRoleRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userRoleId)
        {
            var userRole = await GetByIdAsync(userRoleId);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
        }

        public Task<List<UserRole>> GetAllAsync()
        {
            return _context.UserRoles.ToListAsync();
        }

        public async Task<UserRole> GetByIdAsync(int userRoleId)
        {
            return await _context.UserRoles.FindAsync(userRoleId);
            
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
