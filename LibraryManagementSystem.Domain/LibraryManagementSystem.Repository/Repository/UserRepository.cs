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
            await _context.Set<User>().AddAsync(user);
        }

        public User Delete(int userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            return user;
        }

        public User GetById(int userId)
        {
            return _context.Users.Find(userId)!;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public async Task<User> GetByUserNameOrEmail(string username, string email)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.UserName == username || f.Email == email);
        }
        
        public void Update(User user)
        {
             _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
