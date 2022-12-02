using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Author;
using LybraryManagementSystem.Application.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LybraryManagementSystem.Application.Mappings
{
    public class BookMappings
    {
        public static Book MapToEntity(BookModel bookModel) 
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
            };
        }

        public static List<AuthorModel> AuthorMapToAuthorModelList(List<BookModel> authorNames)
        {
            return authorNames.Select(AuthorMapToAuthorModel).ToList();
        }

        public static AuthorModel AuthorMapToAuthorModel(BookModel bookModel)
        {
            var author = bookModel.AuthorNames.Select(s => new Author
            {
                FirstName = s.AuthorFirstName,
                LastName = s.AuthorLastName,
            });
            return 
        }
        public static Author AuthorMapToEntity(AuthorNameModel authorName)
        {
            return new Author()
            {
                FirstName = authorName.AuthorFirstName,
                LastName = authorName.AuthorLastName,
            };
        }
        public static List<AuthorBook> AuthorBookToEntityList(int bookId, List<Author> authors)
        {
            return authors.Select(s => AuthorBookToEntity(bookId, s)).ToList();
        }

        public static AuthorBook AuthorBookToEntity(int bookId, Author author) 
        {
            return new AuthorBook
            {
                BookId = bookId,
                AuthorId = author.Id
            };
        }

        public static List<Author> AuthorMapToEntityList(BookModel BookModel)
        {
            return BookModel.AuthorNames.Select(s=> new Author 
            {
                FirstName = s.AuthorFirstName,
                LastName= s.AuthorLastName,
            }).ToList();
        }

        public static BookModel AuthorMapToModel(Author author)
        {
            var names = new List<AuthorNameModel>
            {
                new AuthorNameModel()
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                }
            };

            return new BookModel()
            {
                AuthorNames = names,
            };
                
        }

        public static List<Models.Book.BookModel> MapToModelList(List<Book> books)
        {
            if (books != null)
            {
                return books.Select(MapToModel).ToList();
            }

            return null;
        }
    }
}
