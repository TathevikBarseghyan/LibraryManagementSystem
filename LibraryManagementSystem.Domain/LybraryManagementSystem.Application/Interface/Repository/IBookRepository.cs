using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int bookId);
        Task<Book> GetByTitle(string bookTitle);
        Task DeleteAsync(int bookId);
        Task UpdateAsync(Book book);
        Task SaveChangesAsync();
    }
}
