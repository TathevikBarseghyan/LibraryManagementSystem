using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Interface.Repository
{
    public interface IBookInstanceRepository
    {
        Task AddAsync(List<BookInstance> bookInstances);
        Task<List<BookInstance>> GetAllAsync();
        Task<BookInstance> GetByIdAsync(int bookInstanceId);
        Task DeleteAsync(int bookId);
        Task UpdateAsync(BookInstance bookInstance);
        Task SaveChangesAsync();
    }
}
