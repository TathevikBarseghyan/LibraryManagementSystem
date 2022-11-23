using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IUserService 
    {
        void Add(AddModel user);
        List<UserModel> GetAll();
        UserModel GetById(int userId);
        UserModel GetByUserName(string username);
        UserModel Delete(int userId);
        UserModel Update(UserModel user);
    }
}
