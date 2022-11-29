using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IBookService
    {
        Task AddAsync(AddBookModel bookModel);
        Task<List<BookModel>> GetAllAsync();
        Task<BookModel> GetByIdAsync(int bookId);
        Task<BookModel> GetByBookTitle(string bookTitle);
        Task<AddBookModel> GetByAuthorName(string fisrtName, string lastName);
        Task DeleteAsync(int bookId);
        Task UpdateAsync(BookModel book);
        Task BookSaveChangesAsync();
        Task AuthorSaveChangesAsync();
    }
}
