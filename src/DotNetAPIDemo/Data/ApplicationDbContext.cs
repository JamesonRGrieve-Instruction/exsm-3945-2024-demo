using DotNetAPIDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DotNetAPIDemo.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasOne(d => d.Manufacturer)
                .WithMany(p => p.Models)
                .HasForeignKey(d => d.ManufacturerID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"fk_{nameof(DotNetAPIDemo.Models.Model).ToLower()}_{nameof(Manufacturer).ToLower()}");
        });
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasOne(d => d.Model)
                .WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ModelID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName($"fk_{nameof(Vehicle).ToLower()}_{nameof(DotNetAPIDemo.Models.Model).ToLower()}");
        });

    }
}