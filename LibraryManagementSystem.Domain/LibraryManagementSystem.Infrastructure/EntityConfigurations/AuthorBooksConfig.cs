using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure.EntityConfigurations
{
    public class AuthorBooksConfig : IEntityTypeConfiguration<AuthorBook>
    {
        
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(x => new { x.AuthorId, x.BookId });
            builder.HasOne(x => x.Author)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.AuthorId);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.AuthorBooks)
                .HasForeignKey(x => x.BookId);
        }
    }

}
