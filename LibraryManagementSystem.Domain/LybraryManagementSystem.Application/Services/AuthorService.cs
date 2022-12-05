using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.Author;

namespace LybraryManagementSystem.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task AddAsync(AuthorModel authorModel)
        {
            var author = AuthorMappings.MapToEntity(authorModel);
            await _authorRepository.AddAsync(author);
        }

        public async Task AddAsyncList(List<AuthorModel> authorModelList)
        {
            var authors = AuthorMappings.MapToEntityList(authorModelList);
            await _authorRepository.AddAsyncList(authors);
        }

        public async Task DeleteAsync(int authorId)
        {
            var authors = await _authorRepository.GetByIdAsync(authorId);
            if (authors != null)
            {
                await _authorRepository.DeleteAsync(authorId);
            }
        }

        public async Task<List<AuthorModel>> GetAllAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return AuthorMappings.MapToModelList(authors);
        }

        public async Task<AuthorModel> GetByAuthorName(string fistName, string lastName)
        {
            var author = await _authorRepository.GetByAuthorName(fistName, lastName);   
            return AuthorMappings.MapToModel(author);
        }

        public async Task<AuthorModel> GetByIdAsync(int authorId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            return AuthorMappings.MapToModel(author);
        }

        public async Task SaveChangesAsync()
        {
            await _authorRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuthorModel authorModel)
        {
            var author = AuthorMappings.MapToEntity(authorModel);
            await _authorRepository.UpdateAsync(author);

        }
    }
}
