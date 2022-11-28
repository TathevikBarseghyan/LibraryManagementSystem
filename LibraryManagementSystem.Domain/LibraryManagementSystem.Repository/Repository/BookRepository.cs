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
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task DeleteAsync(int bookId)
        {
            var book = await GetByIdAsync(bookId);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int bookId)
        {
            return await _context.Books.FindAsync(bookId);
        }

        public Task<Book> GetByTitle(string bookTitle)
        {
            return _context.Books.FirstOrDefaultAsync(f => f.Title == bookTitle);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var dbBook = _context.Books.First(f => f.Id == book.Id);
            if (dbBook == null)
            {
                return;
            }

            dbBook.AuthorBooks = book.AuthorBooks;
            dbBook.Title = book.Title;
            dbBook.Publisher = book.Publisher;
            dbBook.FixedPrice = book.FixedPrice;


        }
    }
}
