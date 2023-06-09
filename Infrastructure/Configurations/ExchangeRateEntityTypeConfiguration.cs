using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ExchangeRateEntityTypeConfiguration : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> modelBuilder)
    {
        modelBuilder
            .HasIndex(u => new
            {
                u.BaseCurrency,
                u.CounterCurrency,
                u.Date
            })
            .IsUnique();
    }
}