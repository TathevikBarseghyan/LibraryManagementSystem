using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.AuthorBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IAuthorBookService
    {
        Task AddAsync(AuthorBookModel authorBookModel);
        Task<List<AuthorBookModel>> GetAllAsync();
        Task<AuthorBookModel> GetByIdAsync(int authorBookModelId);
        Task DeleteAsync(int authorBookModelId);

        //Task UpdateAsync(AuthorBook authorBook);
        Task SaveChangesAsync();
        Task AddAsyncList(List<AuthorBookModel> authorBookModel);
    }
}
