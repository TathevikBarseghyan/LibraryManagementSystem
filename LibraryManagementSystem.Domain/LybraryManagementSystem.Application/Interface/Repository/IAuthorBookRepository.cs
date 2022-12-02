using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IAuthorBookRepository
    {
        Task AddAsync(AuthorBook authorBook);
        Task<List<AuthorBook>> GetAllAsync();
        Task<AuthorBook> GetByIdAsync(int authorBookId);
        Task DeleteAsync(int authorBookId);
        //Task UpdateAsync(AuthorBook authorBook);
        Task SaveChangesAsync();
    }
}
