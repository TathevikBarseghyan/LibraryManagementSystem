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
    public class BellNotificationConfig : IEntityTypeConfiguration<BellNotification>
    {
        public void Configure(EntityTypeBuilder<BellNotification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);
            
        }
    }
}
