using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Book;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IBookService
    {
        Task AddAsync(AddBookModel bookModel);
        Task<List<BookModel>> GetAllAsync();
        Task<BookModel> GetByIdAsync(int bookId);
        Task<BookModel> GetByBookTitle(string bookTitle);
        Task DeleteAsync(int bookId);
        Task UpdateAsync(BookModel book);
        Task SaveChangesAsync();
    }
}
