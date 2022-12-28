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
    public class EmailNotificationConfig : IEntityTypeConfiguration<EmailNotification>
    {
        public void Configure(EntityTypeBuilder<EmailNotification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Subject).HasMaxLength(50);
            builder.Property(p => p.Body).IsRequired();
            builder.Property(p => p.From).HasMaxLength(50);
            builder.Property(p=>p.ToEmail).HasMaxLength(50);
        }
    }
}
