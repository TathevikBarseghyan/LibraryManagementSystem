using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface.Repository;
using Microsoft.Data.SqlClient;
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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                   var dbBook = await _context.Books.AddAsync(book);

                    await _context.AddRangeAsync(book.AuthorBooks);

                    await _context.BookInstances.AddRangeAsync(book.BookInstances);

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

        public async Task<bool> BookExists(int bookId)
        {
            return await _context.Books.AnyAsync(book => book.Id == bookId);
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
            var dbBook = await _context.Books.FirstAsync(f => f.Id == book.Id);
            if (dbBook == null)
            {
                return;
            }

            dbBook.AuthorBooks = book.AuthorBooks.Select(s => new AuthorBook
            {
                Author = s.Author,
                Book = s.Book

            }).ToList();
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
