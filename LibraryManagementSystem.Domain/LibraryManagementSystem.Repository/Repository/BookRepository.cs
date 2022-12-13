﻿using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.EntityFrameworkCore;

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
            using (LibraryDbContext context = new LibraryDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        await context.Books.AddAsync(book);

                        await context.AddRangeAsync(book.AuthorBooks);

                        await context.BookInstances.AddRangeAsync(book.BookInstances);

                        await SaveChangesAsync();

                        transaction.Commit();

                        //await _context.AuthotBooks.AddAsync(book);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
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

        public async Task<Book> GetByBookTitle(string bookTitle)
        {
            return await _context.Books.FirstOrDefaultAsync(f => f.Title == bookTitle);
        }

        public async Task<Book> BookExists(List<int> author, string title)
        {
             var books = _context.Books
                .Where(w => w.Title == title
                && w.AuthorBooks.All(w => author.Contains(w.AuthorId)));

            //var asdasd = (from book in _context.Books
            //              from aaaa in _context.AuthorBooks
            //              where book.Title == title
            //              && aaaa.BookId == book.Id
            //              && author.Any(a => a.FullName == aaaa.Author.FullName)
            //              select book);

            if (books.Any())
            {
                Book book = books.First();
                return book;
            }

            return null; ;
        }

        //public async Task<bool> AuthorExists(List<int> author)
        //{
        //    var result = _context.Books.Where(w => w.AuthorBooks.All(w => author.Contains(w.AuthorId))).ToList();
        //    return true;
         
        //}
        public async Task<Author> GetByAuthorName(string authorName)
        {
            return await _context.Authors.FirstOrDefaultAsync(f => f.FullName == authorName);
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
            dbBook.DailyPrice = book.DailyPrice;
            dbBook.MonthlyPrice = book.MonthlyPrice;
            dbBook.WeeklyPrice = book.WeeklyPrice;
            dbBook.BookGenre = book.BookGenre;

            _context.Update(dbBook);
            await _context.SaveChangesAsync();
        }
    }
}
