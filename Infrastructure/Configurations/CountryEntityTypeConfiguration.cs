using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> modelBuilder)
        {
            modelBuilder
                .HasIndex(u => u.FullName)
                .IsUnique();
            modelBuilder
                .HasIndex(u => u.CountryCode)
                .IsUnique();
            modelBuilder
                .HasIndex(u => u.FlagImage)
                .IsUnique();
        }
    }
}
