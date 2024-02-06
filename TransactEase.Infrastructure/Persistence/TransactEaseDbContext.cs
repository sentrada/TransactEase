using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using TransactEase.Core.Models;

namespace TransactEase.Infrastructure.Persistence;

public class TransactEaseDbContext : DbContext
{
    public DbSet<Bank> Banks { get; set; }

    public TransactEaseDbContext(DbContextOptions<TransactEaseDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bank>()
            .Property(b => b.Id).HasValueGenerator<SequentialGuidValueGenerator>();
    }
}