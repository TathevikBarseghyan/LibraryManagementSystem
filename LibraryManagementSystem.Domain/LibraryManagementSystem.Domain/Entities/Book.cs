using LibraryManagementSystem.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public BookStatus Status { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }

    }
}
