using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface ILogInService
    {
        void Add(LogInModel user);
        List<LogInModel> GetAll();
        LogInModel GetById(int userId);
        LogInModel GetByUserName(string username);
        LogInModel Delete(int userId);
        LogInModel Update(LogInModel user);
    }
}
