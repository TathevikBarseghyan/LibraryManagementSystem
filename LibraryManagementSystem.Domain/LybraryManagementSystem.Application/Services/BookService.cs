using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models.Book;

namespace LybraryManagementSystem.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        private readonly IBookInstanceService _bookInstanceService;
        private readonly IAuthorBookService _authorBookService;

        public BookService(
            IBookRepository bookRepository,
            IAuthorService authorService,
            IBookInstanceService bookInstanceService,
            IAuthorBookService authorBookService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
            _bookInstanceService = bookInstanceService;
            _authorBookService = authorBookService;
        }

        public async Task AddAsync(BookModel bookModel)
        {
           // var authors = BookMappings.AuthorMapToEntityList(bookModel.AuthorNames);

            var book = BookMappings.MapToEntity(bookModel);
            //var bookInstance = BookInstanceMappings.MapToModel();

            var isBookExists = await _bookRepository.BookExists(bookModel.AuthorIds, bookModel.Title);

            if (isBookExists)
            {
                var bookInstanceModel = BookMappings.BookInstanceMapToModel(book);

                await _bookInstanceService.AddAsync(bookInstanceModel);
            }
            else
            {
                await _bookRepository.AddAsync(book);

                var authorBook = BookMappings.AuthorBookToEntityList(book.Id, bookModel.AuthorIds);
                var authorBookModel = AuthorBookMappings.MapToModelList(authorBook);
                var bookInstanceModel = BookMappings.BookInstanceMapToModel(book);

                await _bookInstanceService.AddAsync(bookInstanceModel);
                await _authorBookService.AddAsyncList(authorBookModel);
            }
        }

        public async Task DeleteAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book != null)
            {
                await _bookRepository.DeleteAsync(book.Id);
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

        public async Task<bool> BookExists(List<int> authorNames, string title)
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

        public async Task UpdateAsync(BookModel bookModel)
        {
            var book = BookMappings.MapToEntity(bookModel);
            await _bookRepository.UpdateAsync(book);
        }
    }
}
