using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.EntityConfigurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasMany(b => b.BookInstances)
                .WithOne(b => b.Book);

            builder.Property(p => p.FixedPrice).HasMaxLength(20);
            builder.Property(p => p.DailyPrice).HasMaxLength(20);
            builder.Property(p => p.MonthlyPrice).HasMaxLength(20);
            builder.Property(p => p.WeeklyPrice).HasMaxLength(20);

            builder.Property(p => p.BookGenre).HasMaxLength(20).IsRequired();
               
            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Publisher)
                .HasMaxLength(100);
        }
    }
}
