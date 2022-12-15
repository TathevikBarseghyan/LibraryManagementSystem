﻿using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.BookInstance;

namespace LybraryManagementSystem.Application.Mappings
{
    public class BookInstanceMappings
    {
        internal static BookInstance MapToEntity(BookInstanceModel bookInstanceModel)
        {
            return new BookInstance
            {
                Id = bookInstanceModel.Id,
                BookId= bookInstanceModel.BookId,
                Status = bookInstanceModel.Status,
                BorrowedDate = bookInstanceModel.BorrowedDate,
                CreationDate = DateTime.Now,
                DueDate = bookInstanceModel.DueDate,
                ReturnDate = bookInstanceModel.ReturnDate,
            };
        }

        public static List<BookInstance> MapToEntity(int count, BookInstanceModel bookInstanceModel)
        {
            var bookinstances = new List<BookInstance>();
            if (count > 1)
            {
                var bookinstance = new BookInstance();
                for (int i = 0; i < count; i++)
                {
                    bookinstance = new BookInstance()
                    {
                        Status = bookInstanceModel.Status,
                        BorrowedDate = null,
                        ReturnDate = null,
                        DueDate = null,
                        CreationDate = DateTime.Now,
                    };
                    bookinstances.Add(bookinstance);
                }
            }
            else
            {
                bookinstances.Add(new BookInstance()
                {
                    Status = bookInstanceModel.Status,
                    BorrowedDate = null,
                    ReturnDate = null,
                    DueDate = null,
                    CreationDate = DateTime.Now,
                });
            }

            return bookinstances;
        }

        public static BookInstanceModel MapToModel(BookInstance bookInstance)
        {
            return new BookInstanceModel
            {
                Id = bookInstance.Id,
                BookId = bookInstance.BookId,
                BorrowedDate = bookInstance.BorrowedDate.Value,
                DueDate = bookInstance.DueDate.Value,
                ReturnDate = bookInstance.ReturnDate.Value,
                CreationDate = bookInstance.CreationDate,
            };
        }

        public static List<BookInstanceModel> MapToModelList(List<BookInstance> bookInstance)
        {
            return bookInstance.Select(MapToModel).ToList();
        }

        public static List<BookInstance> MapToEntityList(int count, List<BookInstanceModel> bookInstanceModels)
        {
            return bookInstanceModels.Select(MapToEntity).ToList();
        }
    }
}