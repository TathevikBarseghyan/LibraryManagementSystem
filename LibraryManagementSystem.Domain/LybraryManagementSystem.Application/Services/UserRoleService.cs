using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public async Task AddAsync(UserRoleModel userRoleModel)
        {
            var userRole = UserRoleMappings.MapToEntity(userRoleModel);
            await _userRoleRepository.AddAsync(userRole);
        }

        public async Task DeleteAsync(int userRoleModelId)
        {
            await _userRoleRepository.DeleteAsync(userRoleModelId);
        }

        public async Task<List<UserRoleModel>> GetAllAsync()
        {
            var userRoles = await _userRoleRepository.GetAllAsync();
            return UserRoleMappings.MapToModelList(userRoles);
        }

        public async Task<UserRoleModel> GetByIdAsync(int userRoleModelId)
        {
            var userRole = await _userRoleRepository.GetByIdAsync(userRoleModelId);
            return UserRoleMappings.MapToModel(userRole);
        }

        public async Task SaveChangesAsync()
        {
            await _userRoleRepository.SaveChangesAsync();
        }
    }
}
