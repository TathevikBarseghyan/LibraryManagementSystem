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
        void Add(User user);
        List<User> GetAll();
        User GetById(int userId);
        User GetByUserName(string username);
        User Delete(int userId);
        User Update(User username);
        void SaveChanges();
    }
}
