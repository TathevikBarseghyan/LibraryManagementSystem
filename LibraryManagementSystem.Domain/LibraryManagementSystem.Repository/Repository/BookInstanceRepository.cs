using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.Repository
{
    public class BookInstanceRepository : IBookInstanceRepository
    {
        private readonly LibraryDbContext _context;

        public BookInstanceRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BookInstance bookInstance)
        {
            await _context.AddAsync(bookInstance);
        }

        public async Task DeleteAsync(int bookId)
        {
            var bookInstance = await GetByIdAsync(bookId);
            if (bookInstance != null)
            {
                _context.BookInstances.Remove(bookInstance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BookInstance>> GetAllAsync()
        {
            return await _context.BookInstances.ToListAsync();
        }

        public async Task<BookInstance> GetByIdAsync(int bookInstanceId)
        {
            return await _context.BookInstances.FindAsync(bookInstanceId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookInstance bookInstance)
        {
            var dbBook = _context.BookInstances.First(f => f.Id == bookInstance.Id);
            if (dbBook == null)
            {
                return;
            }

            dbBook.ReturnDate = bookInstance.ReturnDate;
            dbBook.CreationDate = bookInstance.CreationDate;
            dbBook.BorrowedDate = bookInstance.BorrowedDate;
            dbBook.Status = bookInstance.Status;
            dbBook.Id = bookInstance.Id;    

            _context.Update(dbBook);
            await _context.SaveChangesAsync();
        }
    }
}
