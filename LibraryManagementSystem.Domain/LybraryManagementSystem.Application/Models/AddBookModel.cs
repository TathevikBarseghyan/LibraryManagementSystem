using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enumerations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LybraryManagementSystem.Application.Models
{
    public class AddBookModel 
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public BookGenre BookGenre { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public Decimal FixedPrice { get; set; }
        public Decimal DailyPrice { get; set; }
        public Decimal WeeklyPrice { get; set; }
        public Decimal MonthlyPrice { get; set; }
    }
}
