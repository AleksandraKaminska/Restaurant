using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Models;

namespace Restaurant.Data.EFConfigurations
{
    public class LocalEntityTypeConfiguration : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder) {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.NrOfTables).IsRequired();
            builder.OwnsOne(p => p.Address);
            builder.HasOne(e => e.Menu)
                .WithOne(p => p.Local)
                .HasForeignKey<Menu>(p => p.Id);
        }
    }
}
