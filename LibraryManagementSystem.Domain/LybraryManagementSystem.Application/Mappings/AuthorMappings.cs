using LibraryManagementSystem.Domain.Entities;
using LybraryManagementSystem.Application.Models.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Mappings
{
    public class AuthorMappings
    {
        public static Author MapToEntity(AuthorModel authorModel)
        {
            return new Author()
            {
                FirstName = authorModel.FirstName,
                LastName = authorModel.LastName,
                AuthorBooks = authorModel.AuthorBooks,
                Description = authorModel.Description,
                FullName = authorModel.FullName,
            };
        }

        public static AuthorModel MapToModel(Author author)
        {
            if (author != null)
            {
                return new AuthorModel()
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    AuthorBooks = author.AuthorBooks,
                    Description = author.Description,
                    FullName = author.FullName,
                };
            }

            return null;
        }

        public static List<AuthorModel> MapToModelList(List<Author> authors)
        {
            return authors.Select(MapToModel).ToList();
        }
    }
}
