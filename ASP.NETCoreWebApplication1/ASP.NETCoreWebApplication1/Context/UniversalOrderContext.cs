using Microsoft.EntityFrameworkCore;
using ASP.NETCoreWebApplication1.Models;

namespace ASP.NETCoreWebApplication1.Context;

public class UniversalOrderContext : DbContext
{
    public DbSet<Currency> Currencies { get; set; } = null!;
    public DbSet<CurrencyRatio> CurrencyRatios { get; set; } = null!;
    public DbSet<UniversalOrder> UniversalOrders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost;database=cs_lab;user=sa;password=ABAvA3B6q3UgE6.rWCmYggM7");
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<CurrencyRatio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Ratio).IsRequired();
            entity.HasOne(e => e.Currency)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(e => e.ReferentCurrency)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<UniversalOrder>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Currency)
                .WithMany(c => c.UniversalOrders)
                .OnDelete(DeleteBehavior.NoAction);
            entity.Property(e => e.SenderIban).IsRequired();
            entity.Property(e => e.ReceiverIban).IsRequired();
            entity.Property(e => e.SenderModel).IsRequired();
            entity.Property(e => e.ReceiverModel).IsRequired();
            entity.Property(e => e.Amount).IsRequired();
        });
    }
}