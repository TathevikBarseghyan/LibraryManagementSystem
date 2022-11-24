using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class LogInService : ILogInService
    {
        private readonly IUserRepository _userRepository;
        public LogInService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(LogInModel logInModel)
        {

            var user = UserMappings.LogInMapToEntity(logInModel);
            _userRepository.AddAsync(user);
        }

        public LogInModel Delete(int userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                _userRepository.Delete(userId);
            }

            return user;
        }

        public List<LogInModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public LogInModel GetById(int userId)
        {
            var user = _userRepository.GetById(userId);

            return UserMappings.LogInMapToModel(user);
        }

        public async Task<LogInModel> GetByUserName(string username)
        {
            var user = await _userRepository.GetByUserName(username);

            return UserMappings.LogInMapToModel(user);
        }

        public LogInModel Update(LogInModel user)
        {
            throw new NotImplementedException();
        }
    }
}
