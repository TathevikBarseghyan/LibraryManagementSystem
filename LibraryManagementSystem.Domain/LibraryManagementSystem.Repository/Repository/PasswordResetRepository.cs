using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.Repository
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly LibraryDbContext _context;
        private readonly IUserRepository _userRepository;

        public PasswordResetRepository(LibraryDbContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task AddAsync(PasswordReset passwordReset)
        {
            await _context.PasswordResets.AddAsync(passwordReset);
            await _context.SaveChangesAsync();
        }

        public async Task ResetPasswordAsync(User user)
        {
            await _userRepository.UpdatePasswordAsync(user);
        }
    }
}
