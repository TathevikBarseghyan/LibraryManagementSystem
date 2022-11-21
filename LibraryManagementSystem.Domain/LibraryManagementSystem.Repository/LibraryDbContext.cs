using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Infrastructure
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new BookItemConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new AuthorBooksConfig());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
