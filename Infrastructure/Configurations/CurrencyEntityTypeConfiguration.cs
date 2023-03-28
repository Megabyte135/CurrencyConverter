using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class CurrencyEntityTypeConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> modelBuilder)
        {
            modelBuilder
                .HasIndex(u => u.FullName)
                .IsUnique();
            modelBuilder
                .HasIndex(u => u.CurrencyCode)
                .IsUnique();
            modelBuilder
                .HasIndex(u => u.CurrencySymbol)
                .IsUnique();
        }
    }
}
