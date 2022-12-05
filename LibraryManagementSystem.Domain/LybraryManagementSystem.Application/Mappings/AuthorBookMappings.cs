using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.AuthorBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class AuthorBookMappings
    {
        public static AuthorBook MapToEntity(AuthorBookModel authorBookModel)
        {
            return new AuthorBook
            {
                AuthorId = authorBookModel.AuthorId,
                BookId = authorBookModel.BookId,
            };
        }

        public static AuthorBookModel MapToModel(AuthorBook author)
        {
            return new AuthorBookModel
            {
                AuthorId = author.AuthorId,
                BookId = author.BookId,
            };
        }

        public static List<AuthorBookModel> MapToModelList(List<AuthorBook> authorBooks)
        {
            return authorBooks.Select(MapToModel).ToList();
        }

        internal static List<AuthorBook> MapToEntityList(List<AuthorBookModel> authorBookModel)
        {
            return authorBookModel.Select(MapToEntity).ToList();
        }
    }
}
