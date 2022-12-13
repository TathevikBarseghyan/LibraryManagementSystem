using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repository
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base()
        {
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new AuthorBooksConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }


        public DbSet<Book> Books { get; set; }
        public DbSet<BookInstance> BookInstances { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
