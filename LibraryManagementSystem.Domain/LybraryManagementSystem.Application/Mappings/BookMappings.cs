using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Author;
using LybraryManagementSystem.Application.Models.Book;

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
        public static AuthorModel AuthorMapToAuthorModel(Author authors)
        {
            return new AuthorModel()
            {
                FirstName = authors.FirstName,
                LastName = authors.LastName,
            };
        }
        public static List<AuthorModel> AuthorMapToAuthorModelList(List<Author> authors)
        {
            return authors.Select(AuthorMapToAuthorModel).ToList();
        }

        public static AuthorBook AuthorBookToEntity(int bookId, Author author)
        {
            return new AuthorBook
            {
                BookId = bookId,
                AuthorId = author.Id
            };
        }

        public static List<AuthorBook> AuthorBookToEntityList(int bookId, List<Author> authors)
        {
            return authors.Select(s => AuthorBookToEntity(bookId, s)).ToList();
        }

        public static Author AuthorMapToEntity(AuthorNameModel authorName)
        {
            return new Author()
            {
                FirstName = authorName.AuthorFirstName,
                LastName = authorName.AuthorLastName,
            };
        }

        public static List<Author> AuthorMapToEntityList(BookModel BookModel)
        {
            var authors = BookModel.AuthorNames.Select(s => new Author 
            {
                FirstName = s.AuthorFirstName,
                LastName= s.AuthorLastName,
            }).ToList();

            return authors;
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
