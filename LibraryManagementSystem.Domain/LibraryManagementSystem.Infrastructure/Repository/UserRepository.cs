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
            throw new NotImplementedException();
        }

        public User Get(int userId)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetByUserName(string username)
        {
            throw new NotImplementedException();
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
