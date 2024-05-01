using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Shelf> Shelves { get; set; }

    public DbSet<ShelfProduct> ShelfProducts { get; set; }
    
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ShelfProduct>(x => x.HasKey(p => new { p.ShelfId, p.ProductId }));
        builder.Entity<ShelfProduct>()
            .HasOne(u => u.Shelf)
            .WithMany(u => u.ShelfProducts)
            .HasForeignKey(p => p.ShelfId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Entity<ShelfProduct>()
            .HasOne(u => u.Product)
            .WithMany(u => u.ShelfProducts)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        
        var roles = new List<IdentityRole>
        {
            new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new()
            {
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
}