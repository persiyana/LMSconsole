using EntityFrameworkPlayground.Database.Entities;
using LMSconsole.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace LMSconsole.Database
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Librarian> Librarians { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-64BBGMR;Database=LMSconsole;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(e => e
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade)
            );

            modelBuilder.Entity<Author>(e =>
            {
                e
                .HasMany(a => a.Books)
                .WithOne(a => a.Author)
                .HasForeignKey(a => a.AuthorId);
            });

        }
    }
}
