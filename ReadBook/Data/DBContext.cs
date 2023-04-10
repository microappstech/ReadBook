using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using ReadBook.Models;
using System.Runtime.CompilerServices;

namespace ReadBook.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<BookWriter> Writers_Books  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookWriter>().HasKey(bw => new { bw.BookId, bw.WriterId });

        }

    }
}
 