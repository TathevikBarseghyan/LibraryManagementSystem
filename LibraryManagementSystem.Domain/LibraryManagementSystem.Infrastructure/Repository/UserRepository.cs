using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure;
using LybraryManagementSystem.Application.Interface.Repository;

namespace LibraryManagementSystem.Domain
{
    internal class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;

        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
             _context.Users.Add(user);
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

        public User GetByUserName(string username)
        {
            return _context.Users.Find(username)!;
        }

        public User Update(User username)
        {
            throw new NotImplementedException();
        }

        private bool Validation(string username, string password)
        {
            //var user = FindByUserName(username);
            //if (user != null)
            //{
            //    return user.Password.Equals(password);
            //}

            return false;
        }
    }
}
