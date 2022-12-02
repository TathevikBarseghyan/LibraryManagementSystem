using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Interface;
using LybraryManagementSystem.Application.Interface.Repository;
using LybraryManagementSystem.Application.Mappings;
using LybraryManagementSystem.Application.Models;
using LybraryManagementSystem.Application.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //var authors = BookMappings.AuthorMapToEntityList(bookModel.AuthorNames);

            //var isBookExists = await _bookRepository.Exists(authors, bookModel.Title);
            //if (isBookExists)
            //{
            //   //we only add in BookInstance
            //}

            var IsAuthorNameExists = await _authorService.GetByAuthorName(
                bookModel.AuthorNames.Select(s => s.AuthorFirstName).ToString()
                , bookModel.AuthorNames.Select(s => s.AuthorLastName).ToString());

            var IsBookTitleExists = await _bookRepository.GetByBookTitle(bookModel.Title);

            if (IsAuthorNameExists == null && IsBookTitleExists == null)
            { 
                var book = BookMappings.MapToEntity(bookModel);
                var author = BookMappings.AuthorMapToEntityList(bookModel);
                var authorModel = BookMappings.AuthorMapToAuthorModelList(bookModel.AuthorNames);

                var authorBook = BookMappings.AuthorBookToEntityList(book.Id, author);

                await _bookRepository.AddAsync(book);
                await _authorService.AddAsync(authorModel);
            }
            else if(IsAuthorNameExists != null && IsBookTitleExists == null)
            {

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

        public async Task<bool> Exists(List<Author> authorNames, string title)
        {
            return await _bookRepository.Exists(authorNames, title);
        }

        public async Task<BookModel> GetByAuthorName(string fisrtName,string lastName)
        {
            var authorModel = await _authorService.GetByAuthorName(fisrtName, lastName);
            var authorEntity = AuthorMappings.MapToEntity(authorModel);
            return BookMappings.AuthorMapToModel(authorEntity);
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
