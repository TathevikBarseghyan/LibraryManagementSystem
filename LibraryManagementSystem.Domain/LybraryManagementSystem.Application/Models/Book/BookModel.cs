using LibraryManagementSystem.Domain.Enumerations;

namespace LybraryManagementSystem.Application.Models.Book
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public BookGenre BookGenre { get; set; }
        public List<AuthorNameModel> AuthorNames { get; set; }
        public decimal FixedPrice { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal WeeklyPrice { get; set; }
        public decimal MonthlyPrice { get; set; }
    }
}
