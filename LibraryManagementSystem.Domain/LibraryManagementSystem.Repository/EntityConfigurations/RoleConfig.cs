using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Repository.EntityConfigurations
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Role { Id = (int) RoleType.Admin, Name = RoleType.Admin.ToString() },
                new Role { Id = (int) RoleType.Client, Name = RoleType.Client.ToString() }
                );

            //builder.Property(p => p.RoleName)
        }
    }
}
