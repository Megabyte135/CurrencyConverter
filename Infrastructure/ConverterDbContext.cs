using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Configurations;

namespace Infrastructure
{
    public class ConverterDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ExchangeRateEntityTypeConfiguration().Configure(modelBuilder.Entity<ExchangeRate>());
        }
    }
}