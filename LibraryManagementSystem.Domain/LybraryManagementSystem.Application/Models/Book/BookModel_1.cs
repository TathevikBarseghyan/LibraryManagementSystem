﻿using LibraryManagementSystem.Domain.Enumerations;
using LybraryManagementSystem.Application.Models.Book;

namespace LybraryManagementSystem.Application.Models
{
    public class AddBookModel 
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
