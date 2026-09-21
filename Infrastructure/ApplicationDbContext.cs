using InventoryManagement.Api.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Api.Infrastructure;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<StockMovement> StockMovement { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>(entityBuilder =>
        {
            entityBuilder.HasKey(p => p.Id);

            entityBuilder.Property(p => p.DeletedAt).HasDefaultValue(null);

            entityBuilder.HasQueryFilter(p => p.DeletedAt == null);
        });

        modelBuilder.Entity<StockMovement>(entityBuilder =>
        {
            entityBuilder.HasKey(p => p.Id);

            entityBuilder
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder
                .HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            entityBuilder
                .Property(p => p.MovedAt)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW()");

            entityBuilder.Property(p => p.Type).HasConversion<string>();

            entityBuilder.Property(p => p.Reason).HasConversion<string>();
        });
    }
}
