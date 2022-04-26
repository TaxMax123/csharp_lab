using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Context;

public class UniversalOrderContext : DbContext
{
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<CurrencyRatio> CurrencyRatios { get; set; }
    public DbSet<UniversalOrder> UniversalOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=localhost;database=cs_lab;user=sa;password=12345678");
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