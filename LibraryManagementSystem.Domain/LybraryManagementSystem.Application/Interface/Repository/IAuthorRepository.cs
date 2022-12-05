using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IAuthorRepository
    {
        Task AddAsync(Author author);
        Task AddAsyncList(List<Author> authorList);
        Task<List<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int authorId);
        Task<Author> GetByAuthorName(string fistName, string lastName);
        Task DeleteAsync(int authorId);
        Task UpdateAsync(Author author);
        Task SaveChangesAsync();
    }
}
