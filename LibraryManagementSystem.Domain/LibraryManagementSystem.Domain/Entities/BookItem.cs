using LibraryManagementSystem.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class BookItem : Book
    {
        public DateTime BorowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public BookStatus Status { get; set; }

    }
}
