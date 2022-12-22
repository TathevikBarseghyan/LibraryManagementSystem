using LybraryManagementSystem.Application.Models.AuthorBook;
using LybraryManagementSystem.Application.Models.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IUserRoleService
    {
        Task AddAsync(UserRoleModel userRoleModel);
        Task<List<UserRoleModel>> GetAllAsync();
        Task<UserRoleModel> GetByIdAsync(int userRoleModelId);
        Task DeleteAsync(int userRoleModelId);

        //Task UpdateAsync(AuthorBook authorBook);
        Task SaveChangesAsync();
    }
}
