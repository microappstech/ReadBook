using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadBook.Models;
namespace ReadBook.Areas.Identity.Data;

public class ReadBookContext : IdentityDbContext<AppUser>
{
    public ReadBookContext(DbContextOptions<ReadBookContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<IdentityUser>()
        //    .ToTable("Users")
        //    .Ignore(t => t.EmailConfirmed);

        //builder.Entity<IdentityRole>().ToTable("Roles");
        //builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");


    }
}
