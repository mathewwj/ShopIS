using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Shelf> Shelves { get; set; }
    
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasOne(p => p.Shelf)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ShelfId)
            .OnDelete(DeleteBehavior.Restrict);

        
        var roles = new List<IdentityRole>
        {
            new()
            {
                Name = nameof(UserRole.Admin),
                NormalizedName = nameof(UserRole.Admin).ToUpper()
            },
            new()
            {
                Name = nameof(UserRole.User),
                NormalizedName = nameof(UserRole.User).ToUpper()
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}