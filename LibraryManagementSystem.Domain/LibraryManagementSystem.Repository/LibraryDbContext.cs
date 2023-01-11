using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.EntityConfigurations;
using LibraryManagementSystem.Repository.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new AuthorBooksConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new EmailNotificationConfig());
            modelBuilder.ApplyConfiguration(new BellNotificationConfig());
            modelBuilder.ApplyConfiguration(new PasswordResetConfig());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookInstance> BookInstances { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<EmailNotification> EmailNotifications { get; set; }
        public DbSet<BellNotification> BellNotifications { get; set; }
        public DbSet<PasswordReset> PasswordResets { get; set; }
    }
}
