using BookAPI.Data.Configurations;
using BookAPI.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data.DAL
{
    public class BookDbContext: IdentityDbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genr> Genrs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new GenrConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
