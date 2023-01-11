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
    public class AuthorBookRepository : IAuthorBookRepository
    {
        private readonly LibraryDbContext _context;
        public AuthorBookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AuthorBook authorBook)
        {
            
            await _context.AuthorBooks.AddAsync(authorBook);
            await SaveChangesAsync();
            
        }

        public async Task AddAsyncList(List<AuthorBook> authorBooks)
        {
            await _context.AuthorBooks.AddRangeAsync(authorBooks);
        }

        public async Task DeleteAsync(int authorBookId)
        {
            var authorBook = await GetByIdAsync(authorBookId);
            if (authorBook != null)
            {
                _context.AuthorBooks.Remove(authorBook);
                await _context.SaveChangesAsync();
            }
        }

        public  Task<List<AuthorBook>> GetAllAsync()
        {
            return  _context.AuthorBooks.ToListAsync();
        }

        public async Task<AuthorBook> GetByIdAsync(int authorBookId)
        {
            return await _context.AuthorBooks.FindAsync(authorBookId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
