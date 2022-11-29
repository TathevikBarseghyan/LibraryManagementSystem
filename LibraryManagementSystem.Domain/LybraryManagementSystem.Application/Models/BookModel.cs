using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public BookGenre BookGenre { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
        public Decimal FixedPrice { get; set; }
        public Decimal DailyPrice { get; set; }
        public Decimal WeeklyPrice { get; set; }
        public Decimal MonthlyPrice { get; set; }
    }
}
