using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserModel userModel)
        {
            var user = Mappings.UserMappings.MapToEntity(userModel);
             _userRepository.Add(user);
        }

        public UserModel Delete(int userId)
        {
            UserModel userModel = new UserModel();

            var user = GetById(userId);
            if (user != null)
            {
                _userRepository.Delete(user.Id);
            }

            return user;
        }

        public UserModel GetById(int userId)
        {
            UserModel userModel = new UserModel();
            var user = _userRepository.GetById(userId);

            userModel = user;

            return userModel;
        }

        public List<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUserName(string username)
        {
            throw new NotImplementedException();
        }

        public UserModel Update(UserModel user)
        {
            throw new NotImplementedException();
        }

      
    }
}
