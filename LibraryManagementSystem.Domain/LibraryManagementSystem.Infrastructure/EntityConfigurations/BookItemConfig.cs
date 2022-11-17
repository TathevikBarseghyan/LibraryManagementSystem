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
    public class BookItemConfig : IEntityTypeConfiguration<BookItem>
    {
        public void Configure(EntityTypeBuilder<BookItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(BookStatus.Available);
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.BorowedDate).IsRequired();


        }
    }
}
