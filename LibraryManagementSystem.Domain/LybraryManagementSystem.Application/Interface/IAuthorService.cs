using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Author;
using LybraryManagementSystem.Application.Models.Book;

namespace LybraryManagementSystem.Application.Interface
{
    public interface IAuthorService
    {
        Task AddAsync(AuthorModel authorModel);
        Task AddAsyncList(List<AuthorModel> authorModelList);
        Task<List<AuthorModel>> GetAllAsync();
        Task<AuthorModel> GetByIdAsync(int authorId);
        Task<AuthorModel> GetByAuthorName(string fistName, string lastName);
        Task DeleteAsync(int authorId);
        Task UpdateAsync(AuthorModel authorModel);
        Task SaveChangesAsync();
    }
}
