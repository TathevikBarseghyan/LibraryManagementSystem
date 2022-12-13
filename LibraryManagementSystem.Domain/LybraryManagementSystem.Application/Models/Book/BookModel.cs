using LibraryManagementSystem.Domain.Enumerations;
using LybraryManagementSystem.Application.Models.BookInstance;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LybraryManagementSystem.Application.Models.Book
{
    public class BookModel
    {
        //[JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public BookGenre BookGenre { get; set; }
        public List<int> AuthorIds { get; set; }
        public decimal FixedPrice { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
        public BookStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public BookInstanceModel BookInstance { get; set; }
        public int Count { get; set; }
    }
}
