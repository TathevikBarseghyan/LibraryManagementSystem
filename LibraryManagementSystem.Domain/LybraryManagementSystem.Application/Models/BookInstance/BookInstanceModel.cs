using LibraryManagementSystem.Domain.Enumerations;
using LibraryManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models.BookInstance
{
    public class BookInstanceModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public BookStatus Status { get; set; }
    }
}
