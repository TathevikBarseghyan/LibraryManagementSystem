using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class BookMappings
    {
        public static Book BookMapToEntity(BookModel bookModel) 
        {
            return new Book()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                BookGenre = bookModel.BookGenre,
                Publisher = bookModel.Publisher,
                FixedPrice = bookModel.FixedPrice,
                DailyPrice = bookModel.DailyPrice,
                MonthlyPrice = bookModel.MonthlyPrice,
                WeeklyPrice = bookModel.WeeklyPrice,
                AuthorBooks = bookModel.AuthorBooks,
            };
        }

        public static Book BookMapToEntity(AddBookModel addBookModel)
        {
            var book = new Book()
            {
                Title = addBookModel.Title,
                BookGenre = addBookModel.BookGenre,
                Publisher = addBookModel.Publisher,
                FixedPrice = addBookModel.FixedPrice,
                DailyPrice = addBookModel.DailyPrice,
                MonthlyPrice = addBookModel.MonthlyPrice,
                WeeklyPrice = addBookModel.WeeklyPrice,
            };

            var author = AuthorMapToEntity(addBookModel);
            
            book.AuthorBooks = new List<AuthorBook>
            {
                new AuthorBook
                {
                    Book = book,
                    Author = author
                }
            };

            return book;
        }
        public static Author AuthorMapToEntity(AddBookModel addBookModel)
        {
            return new Author()
            {
                FirstName = addBookModel.AuthorFirstName,
                LastName = addBookModel.AuthorLastName,
            };
        }

        public static AddBookModel AuthorMapToModel(Author author)
        {
            return new AddBookModel()
            {
              AuthorFirstName= author.FirstName,
              AuthorLastName= author.LastName,
            };
        }

        public static BookModel MapToModel(Book book)
        {
            return new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                BookGenre = book.BookGenre,
                Publisher = book.Publisher,
                FixedPrice = book.FixedPrice,
                DailyPrice = book.DailyPrice,
                MonthlyPrice = book.MonthlyPrice,
                WeeklyPrice = book.WeeklyPrice,
                AuthorBooks = book.AuthorBooks,
            };
        }

        internal static List<BookModel> MapToModelList(List<Book> books)
        {
            if (books != null)
            {
                return books.Select(MapToModel).ToList();
            }

            return null;
        }
    }
}
