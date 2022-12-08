using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
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
        Task<Book> GetByBookTitle(string bookTitle);
        Task<Book> BookExists(List<int> authorNames, string bookTitle);
        //Task<bool> AuthorExists(List<int> authorNames);
        Task<Author> GetByAuthorName(string authorName);
        Task DeleteAsync(int bookId);
        Task UpdateAsync(Book book);
        Task SaveChangesAsync();
    }
}
