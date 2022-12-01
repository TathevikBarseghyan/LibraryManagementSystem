using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.BookInstance;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(BookInstanceModel bookInstanceModel)
        {
            var bookInstance = BookInstanceMappings.MapToEntity(bookInstanceModel);
            await _bookInstanceRepository.AddAsync(bookInstance);
        }

        public Task DeleteAsync(int bookInstanceModelId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookInstanceModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BookInstanceModel> GetByIdAsync(int bookInstanceModelId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _bookInstanceRepository.SaveChangesAsync();
        }

        public Task UpdateAsync(BookInstanceModel bookInstanceModel)
        {
            throw new NotImplementedException();
        }
    }
}
