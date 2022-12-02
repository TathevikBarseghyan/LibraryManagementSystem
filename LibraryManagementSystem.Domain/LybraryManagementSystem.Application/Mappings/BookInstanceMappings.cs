using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.BookInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class BookInstanceMappings
    {
        internal static BookInstance MapToEntity(BookInstanceModel bookInstanceModel)
        {
            return  new BookInstance
            {
                Id = bookInstanceModel.Id,
                Status = bookInstanceModel.Status,
                BorrowedDate = bookInstanceModel.BorrowedDate,
                CreationDate = bookInstanceModel.CreationDate,
                DueDate = bookInstanceModel.DueDate,
                ReturnDate = bookInstanceModel.ReturnDate,
            };
        }

        public static BookInstanceModel MapToModel(BookInstance bookInstance)
        {
            return new BookInstanceModel
            { 
                Id = bookInstance.Id,
                BorrowedDate = bookInstance.BorrowedDate,
                CreationDate = bookInstance.CreationDate,
                DueDate = bookInstance.DueDate,
                ReturnDate = bookInstance.ReturnDate,
            };
        }

        public static List<BookInstanceModel> MapToModelList(List<BookInstance> bookInstance)
        {
            return bookInstance.Select(MapToModel).ToList();
        }
    }
}
