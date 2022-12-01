using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models;
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
                AuthorBooks = bookModel.AuthorBooks,
            };
        }

        public static Book MapToEntity(AddBookModel addBookModel)
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

            //var author = AuthorMapToEntity(addBookModel);

            //book.AuthorBooks = new List<AuthorBook>
            //{
            //    new AuthorBook
            //    {
            //        Book = book,
            //        Author = author
            //    }
            //};

            return book;
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

        public static List<Author> AuthorMapToEntity(List<AuthorNameModel> authorNames)
        {
            return authorNames.Select(AuthorMapToEntity).ToList();
        }

        public static Author AuthorMapToEntity(AuthorNameModel authorName)
        {
            return new Author()
            {
                FirstName = authorName.AuthorFirstName,
                LastName = authorName.AuthorLastName,
            };
        }
        public static Book AuthorBookMapper(Book book, List<Author> authors)
        {
            return authors.Select<Book,Author>(AuthorBookMapper).ToList();
        }

        public static Book AuthorBookMapper(Book book, Author author) 
        {
            book.AuthorBooks = new List<AuthorBook>
            {
                new AuthorBook
                {
                    BookId = book.Id,
                    Author = author
                }
            };

            return book;
        }
        public static Author AuthorMapToEntity(AddBookModel addBookModel, Book book)
        {
            var authors = addBookModel.AuthorNames.Select(s=> new Author 
            {
                FirstName = s.AuthorFirstName,
                LastName= s.AuthorLastName,
            }).ToList();

            var author = new Author()
            {
                FirstName = addBookModel.AuthorNames.ToArray().Select(s => s.AuthorFirstName).ToString(),
                LastName = addBookModel.AuthorNames.ToArray().Select(s => s.AuthorLastName).ToString(),
            };

            return author;
        }

        //Error
        //public static List<Author> AuthorMapToEntityList(List<AuthorNameModel> authorNameModel)
        //{
        //    return authorNameModel.Select(AuthorMapToEntity).ToList();
        //}

        public static AddBookModel AuthorMapToModel(Author author)
        {
            var names = new List<AuthorNameModel>
            {
                new AuthorNameModel()
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                }
            };

            return new AddBookModel()
            {
                AuthorNames = names,
            };
                
        }

        public static List<BookModel> MapToModelList(List<Book> books)
        {
            if (books != null)
            {
                return books.Select(MapToModel).ToList();
            }

            return null;
        }
    }
}
