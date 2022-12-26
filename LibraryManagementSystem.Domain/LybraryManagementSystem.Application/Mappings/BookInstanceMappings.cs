using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.BookInstance;

namespace LybraryManagementSystem.Application.Mappings
{
    public class BookInstanceMappings
    {
        public static BookInstance MapToEntity(BookInstanceModel bookInstanceModel)
        {
            return new BookInstance
            {
                Id = bookInstanceModel.Id,
                BookId= bookInstanceModel.BookId,
                Status = bookInstanceModel.Status,
                BorrowedDate = bookInstanceModel.BorrowedDate,
                DueDate = bookInstanceModel.DueDate,
                ReturnDate = bookInstanceModel.ReturnDate,
            };
        }

        public static List<BookInstance> MapToEntity(int count, BookInstanceModel bookInstanceModel)
        {
           
            var bookinstances = new List<BookInstance>();
            if (count > 1)
            {
                for (int i = 0; i < count; i++)
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
                BorrowedDate = bookInstance.BorrowedDate,
                DueDate = bookInstance.DueDate,
                ReturnDate = bookInstance.ReturnDate,
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
