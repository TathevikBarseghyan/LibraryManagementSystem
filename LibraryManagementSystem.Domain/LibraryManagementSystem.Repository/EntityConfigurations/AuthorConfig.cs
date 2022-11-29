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
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasComputedColumnSql(" [FirstName] + ' ' + [LastName] ")
                .HasMaxLength(100);

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(255)
                .HasDefaultValue("Author");

        }
    }
}
