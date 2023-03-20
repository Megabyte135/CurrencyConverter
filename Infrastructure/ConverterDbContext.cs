using Microsoft.EntityFrameworkCore;
using Domain.Models;
using System.Reflection.Metadata;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace Infrastructure
{
    public class ConverterDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public ConverterDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}