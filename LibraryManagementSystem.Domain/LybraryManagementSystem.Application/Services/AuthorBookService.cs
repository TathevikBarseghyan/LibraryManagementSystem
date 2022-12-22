using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.AuthorBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class AuthorBookService : IAuthorBookService
    {
        private readonly IAuthorBookRepository _authorBookRepository;
        public AuthorBookService(IAuthorBookRepository authorBookRepository)
        {
            _authorBookRepository = authorBookRepository;
        }

        public async Task AddAsync(AuthorBookModel authorBookModel)
        {
            var authorBook = AuthorBookMappings.MapToEntity(authorBookModel);
            await _authorBookRepository.AddAsync(authorBook);
        }

        public async Task AddAsyncList(List<AuthorBookModel> authorBookModel)
        {
            var authorBookList = AuthorBookMappings.MapToEntityList(authorBookModel);
            await _authorBookRepository.AddAsyncList(authorBookList);
        }

        public async Task DeleteAsync(int authorBookModelId)
        {
            _authorBookRepository.DeleteAsync(authorBookModelId);
        }

        public async Task<List<AuthorBookModel>> GetAllAsync()
        {
            var authorBooks = await _authorBookRepository.GetAllAsync();
            return AuthorBookMappings.MapToModelList(authorBooks);
        }

        public async Task<AuthorBookModel> GetByIdAsync(int authorBookModelId)
        {
            var author = await _authorBookRepository.GetByIdAsync(authorBookModelId);
            return AuthorBookMappings.MapToModel(author);
        }

        public async Task SaveChangesAsync()
        {
            await _authorBookRepository.SaveChangesAsync();
        }
    }
}
