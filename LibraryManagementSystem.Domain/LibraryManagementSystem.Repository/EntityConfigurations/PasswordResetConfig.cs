using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository.EntityConfigurations
{
    public class PasswordResetConfig : IEntityTypeConfiguration<PasswordReset>
    {
        public void Configure(EntityTypeBuilder<PasswordReset> builder)
        {
            builder.Property(p =>p.UserId).IsRequired();

            builder.Property(p =>p.GuId)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(p => p.Date).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x=>x.PasswordReset)
                .HasForeignKey(x=>x.UserId);
        }
    }
}
