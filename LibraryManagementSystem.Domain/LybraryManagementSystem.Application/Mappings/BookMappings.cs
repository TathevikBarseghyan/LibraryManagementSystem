using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Author;
using LybraryManagementSystem.Application.Models.Book;
using LybraryManagementSystem.Application.Models.BookInstance;

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
                AuthorBooks = AuthorBookMappings.MapToEntityList(bookModel.AuthorIds.Select(s => new Models.AuthorBook.AuthorBookModel 
                { 
                    BookId = bookModel.Id, 
                    AuthorId = s 
                }).ToList()),
                BookInstances = BookInstanceMappings.MapToEntity(bookModel.BookInstance, bookModel.Count)
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

        public static AuthorBook AuthorBookToEntity(int bookId, int authorId)
        {
            return new AuthorBook
            {
                BookId = bookId,
                AuthorId = authorId
            };
        }

        public static List<AuthorBook> AuthorBookToEntityList(int bookId, List<int> authors)
        {
            return authors.Select(s => AuthorBookToEntity(bookId, s)).ToList();
        }

        public static Author AuthorMapToEntity(BookModel bookModel)
        {
            return new Author()
            { 
                Id = bookModel.Id
            };
        }

        public static List<Author> AuthorMapToEntityList(BookModel bookModel)
        {
            return bookModel.AuthorIds.Select(s => AuthorMapToEntity(bookModel)).ToList();
        }

        public static List<BookModel> MapToModelList(List<Book> books)
        {
            if (books != null)
            {
                return books.Select(MapToModel).ToList();
            }

            return null;
        }

        public static BookInstanceModel MapToBookInstanceModel(Book book)
        {
            return new BookInstanceModel()
            {
                BookId = book.Id,
                //CreationDate = DateTime.Now,
                //BorrowedDate = book.BookInstances.Select(s => s.BorrowedDate).
            };
        }
    }
}
