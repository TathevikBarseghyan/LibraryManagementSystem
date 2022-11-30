﻿using LibraryManagementSystem.Domain.Entities;
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
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task AddAsync(AddBookModel bookModel)
        {

            var authors = BookMappings.AuthorMapToEntityList(bookModel.AuthorNames);
            var isBookExists = await _bookRepository.Exists(authors, bookModel.Title);
            if (isBookExists)
            {
               
            }

            var book = BookMappings.MapToEntity(bookModel);
            await _bookRepository.AddAsync(book);



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

        public async Task<AddBookModel> GetByAuthorName(string fisrtName,string lastName)
        {
            var author = await _authorRepository.GetByAuthorName(fisrtName, lastName);
            return BookMappings.AuthorMapToModel(author);
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
            await _authorRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookModel bookModel)
        {
            var book = BookMappings.MapToEntity(bookModel);
            await _bookRepository.UpdateAsync(book);
        }
    }
}
