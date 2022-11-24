using LibraryManagementSystem.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class BookItem : Book
    {
        [DataType(DataType.Date)]
        public DateTime BorowedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public BookStatus Status { get; set; }

    }
}
