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
            var book = new Book()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                BookGenre = bookModel.BookGenre,
                Publisher = bookModel.Publisher,
                FixedPrice = bookModel.FixedPrice,
                DailyPrice = bookModel.DailyPrice,
                MonthlyPrice = bookModel.MonthlyPrice,
                WeeklyPrice = bookModel.WeeklyPrice,
                BookInstances = BookInstanceMappings.MapToEntity(bookModel.Count, bookModel.BookInstance)
            };

            book.AuthorBooks = bookModel.AuthorIds.Select(s => new AuthorBook
            {
                Book = book,
                AuthorId = s
            }).ToList();

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

        public static List<BookInstanceModel> MapToBookInstanceModel(BookModel bookModel, int count, int bookId)
        {
            var bookinstanceModels = new List<BookInstanceModel>();
            if (count > 1)
            {
                var bookInstanceModel = new BookInstanceModel();
                for (int i = 0; i < count; i++)
                {
                    bookInstanceModel = new BookInstanceModel()
                    {
                        BookId = bookId,
                        CreationDate = DateTime.Now,
                        BorrowedDate = null,
                        DueDate = null,
                        ReturnDate = null,
                    };
                    bookinstanceModels.Add(bookInstanceModel);
                }
            }
            else
            {
                bookinstanceModels.Add(new BookInstanceModel()
                {
                    BookId = bookId,
                    Status = bookModel.Status,
                    BorrowedDate = null,
                    ReturnDate = null,
                    DueDate = null,
                    CreationDate = DateTime.Now,
                });
            }

            return bookinstanceModels;

            //    BookInstanceModel()
            //{
            //    BookId = bookModel.Id,
            //    BorrowedDate = bookModel.BookInstance.BorrowedDate,
            //    CreationDate = DateTime.Now,
            //    DueDate = bookModel.BookInstance.DueDate,
            //    ReturnDate= bookModel.BookInstance.ReturnDate,
            //};
        }
    }
}
