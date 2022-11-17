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
            var user = Mappings.UserMappings.MappToEntity(userModel);
            _userRepository.Add(user);
        }

        public UserModel Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public UserModel Get(int userId)
        {
            throw new NotImplementedException();
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
