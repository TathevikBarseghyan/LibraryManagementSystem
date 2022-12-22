using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;

        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dbUser = await _context.Users.AddAsync(user);

                    await _context.AddRangeAsync(user.UserRoles);

                    await SaveChangesAsync();

                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await GetByIdAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();  
            }
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.UserName == username);
        }
        
        public async Task UpdateAsync(User user)
        {
            var dbUser = _context.Users.First(f => f.Id == user.Id);
            if (dbUser == null)
            {
                return;
            }

            dbUser.UserName = user.UserName;
            dbUser.FirstName= user.FirstName;
            dbUser.LastName= user.LastName;
            dbUser.Email= user.Email;

            _context.Users.Update(dbUser);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
