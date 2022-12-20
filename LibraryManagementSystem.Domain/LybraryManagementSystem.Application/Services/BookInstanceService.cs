using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.Book;
using LybraryManagementSystem.Application.Models.BookInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Services
{
    public class BookInstanceService : IBookInstanceService
    {
        private readonly IBookInstanceRepository _bookInstanceRepository;
        public BookInstanceService(IBookInstanceRepository bookInstanceRepository)
        {
            _bookInstanceRepository = bookInstanceRepository;
        }

        public async Task AddRangeAsync(List<BookInstanceModel> bookInstanceModels)
        {
            var bookInstance = BookInstanceMappings.MapToEntityList(bookInstanceModels.Count, bookInstanceModels);
            await _bookInstanceRepository.AddRangeAsync(bookInstance);
        }

        public async Task DeleteAsync(int bookInstanceModelId)
        {
            _bookInstanceRepository.DeleteAsync(bookInstanceModelId);
        }

        public async Task<List<BookInstanceModel>> GetAllAsync()
        {
            var bookInstance = await _bookInstanceRepository.GetAllAsync();
            return BookInstanceMappings.MapToModelList(bookInstance);
        }

        public async Task<List<BookInstanceModel>> GetByBookIdAsync(int bookId)
        {
            var bookInstance = await _bookInstanceRepository.GetByBookIdAsync(bookId);
            return BookInstanceMappings.MapToModelList(bookInstance); 
        }

        public async Task<BookInstanceModel> GetByIdAsync(int bookInstanceModelId)
        {
            var bookInstance =  await _bookInstanceRepository.GetByIdAsync(bookInstanceModelId);
            return BookInstanceMappings.MapToModel(bookInstance);
        }

        public async Task SaveChangesAsync()
        {
            await _bookInstanceRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookInstanceModel bookInstanceModel)
        {
            var book = BookInstanceMappings.MapToEntity(bookInstanceModel);
            await _bookInstanceRepository.UpdateAsync(book);
        }
    }
}
