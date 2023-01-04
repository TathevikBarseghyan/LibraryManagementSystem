using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Book;

namespace LybraryManagementSystem.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly IBookInstanceService _bookInstanceService;
        private readonly IAuthorBookService _authorBookService;
        private readonly INotificationService _notificationService;
        public BookService(
            IBookRepository bookRepository,
            IAuthorService authorService,
            IBookInstanceService bookInstanceService,
            IAuthorBookService authorBookService,
            INotificationService notificationService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _bookInstanceService = bookInstanceService;
            _authorBookService = authorBookService;
            _notificationService = notificationService;
        }

        public async Task AddAsync(BookModel bookModel)
        {
            var existedBook = await _bookRepository.BookExists(bookModel.AuthorIds, bookModel.Title);

            if (existedBook != null)
            {
                var bookInstanceModel = BookMappings.MapToBookInstanceModel(bookModel, bookModel.Count, existedBook.Id);

                await _bookInstanceService.AddRangeAsync(bookInstanceModel);
            }
            else
            {
                var book = BookMappings.MapToEntity(bookModel);
                
                await _bookRepository.AddAsync(book);

                await _notificationService.AddingBookEmailAsync();
            }
        }

        public async Task DeleteAsync(int bookId)
        {
            var bookExists = await _bookRepository.BookExists(bookId);
            if (bookExists)
            {
                await _bookRepository.DeleteAsync(bookId);
            }
        }

        public async Task<List<BookModel>> GetAllAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return BookMappings.MapToModelList(books);
        }

        public async Task<BookModel> GetByBookTitle(string bookTitle)
        {
            var book = await _bookRepository.GetByBookTitle(bookTitle);
            return BookMappings.MapToModel(book);
        }
        public async Task<Book> BookExists(List<int> authorNames, string title)
        {
            return await _bookRepository.BookExists(authorNames, title);
        }

        public async Task<BookModel> GetByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            return BookMappings.MapToModel(book);

        }
        public async Task SaveChangesAsync()
        {
            await _bookRepository.SaveChangesAsync();
        }
        public async Task AuthorSaveChangesAsync()
        {
            await _authorService.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookEditModel bookEditModel)
        {
            var book = BookMappings.EditModelMapToEntity(bookEditModel);
            await _bookRepository.UpdateAsync(book);
        }
    }
}
