using Microsoft.EntityFrameworkCore;
using Domain.Models;
using Infrastructure.Configurations;
using Infrastructure.Configurations.Converters;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public class ConverterDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public ConverterDbContext(DbContextOptions<ConverterDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ExchangeRateEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<ExchangeRate>());
            new CurrencyEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<Currency>());
            new CountryEntityTypeConfiguration()
                .Configure(modelBuilder.Entity<Country>());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<Currency>()
                .HaveConversion<CurrencyEntityTypeConverter>();
        }
    }
}