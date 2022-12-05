using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;
        public AuthorRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Author author)
        {
            await _context.AddAsync(author);
        }

        public async Task AddAsyncList(List<Author> authorList)
        {
            await _context.AddRangeAsync(authorList);
        }

        public async Task DeleteAsync(int authorId)
        {
            var author = await GetByIdAsync(authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByAuthorName(string firstName, string lastName)
        {
            return await _context.Authors.FirstOrDefaultAsync(f => f.FirstName == firstName && f.LastName == lastName);
        }

        public async Task<Author> GetByIdAsync(int authorId)
        {
            return await _context.Authors.FindAsync(authorId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            var dbBook = _context.Authors.First(f => f.Id == author.Id);
            if (dbBook == null)
            {
                return;
            }

            dbBook.FirstName = author.FirstName; 
            dbBook.LastName = author.LastName;
            dbBook.FullName = author.FullName;

            _context.Update(dbBook);
            await _context.SaveChangesAsync();
        }
    }
}
